using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Product.Core.DbStructs;
using SharedLiberary.Core.Interfaces;
using SharedLiberary.Models.UserManagment;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HealthApp.EF.Reposiotries
{
    public class AutherReposity:IAutherRepository
    {
        private readonly UserManager<ApplicationUser> _uManage;
        private readonly RoleManager<IdentityRole> _rManager;
        readonly UserJWT _userJWT;
        public AutherReposity(UserManager<ApplicationUser> userManager, IOptions<UserJWT> jWT, RoleManager<IdentityRole> roleManager)
        { _uManage=userManager; _userJWT=jWT.Value; _rManager=roleManager; }

        public async Task<string> AddRoleAsync(AddRoleModel role)
        {
            var user = await _uManage.FindByIdAsync(role.UserID);

            if (user is null || !await _rManager.RoleExistsAsync(role.RoleName))
                return "User or Role not found";

            if (await _uManage.IsInRoleAsync(user, role.RoleName))
                return string.Empty;

            var result = await _uManage.AddToRoleAsync(user, role.RoleName);
            return result.Succeeded ?
                "User added to role successfully" : "Something went wrong";

        }

        public async Task<ApplicationUser> ExistMailAsync(string email) =>
                await _uManage.Users.FirstOrDefaultAsync(u => u.Email==email);



        public async Task<AutherModel> GetTokenAsync(TokenRequestModel token)
        {
            var autherModel = new AutherModel();
            var user = await ExistMailAsync(token.Email);

            if (user is null || !await _uManage.CheckPasswordAsync(user, token.Password))
            {
                autherModel.Message="Email or Passwork is wrong ";
                return autherModel;
            }
            var jwtSecurityToken = await CreateJwtToken(user);
            var roles = await _uManage.GetRolesAsync(user);
            RefreshToken userToken = new RefreshToken();
         
            if (user.RefrshTokens.Any(t => t.IsActive))
                userToken = user.RefrshTokens.FirstOrDefault(t => t.IsActive);
            else
            {
                userToken = GenerateRefrshToken();
                user.RefrshTokens.Add(userToken);
                await _uManage.UpdateAsync(user);
            }

            return new AutherModel
            {
                Email=user.Email,
                IsAuthenticated=true,
                Message="User Exist",
                Roles=roles.ToList(),
                Token=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName=user.UserName,
                RefreshToken=userToken.Token,
                RefreshTokenExpiration=userToken.ExpiresOn
            };
        }

        public async Task<AutherModel> RegisterAsync(RegisterModel regist)
        {
            var auther = await this.ExistMailAsync(regist.Email);
            if (auther is not null)
                return new AutherModel { Message = "Email already exists" };

            if (await _uManage.FindByNameAsync(regist.UserName) is not null)
                return new AutherModel { Message = "User name already exists" };

            /*var user = new ApplicationUser();
            _userMap.Map(regist, user);*/ // Map the RegisterModel to ApplicationUser
            ApplicationUser user = new ApplicationUser
            {
                FirstName=regist.FirstName,
                LastName=regist.LastName,
                UserName=regist.UserName,
                Email=regist.Email,
            };

            var result = await _uManage.CreateAsync(user, regist.Password);
            var errors = string.Empty;
            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                    errors+= $"{err.Description}, ";

                return new AutherModel { Message=errors };
            }
            await _uManage.AddToRoleAsync(user, RolesList.User);

            var jwtSecurityToken = await CreateJwtToken(user);
            return new AutherModel
            {
                Email=user.Email,
                //ExpiresOn= jwtSecurityToken.ValidTo,
                IsAuthenticated=true,
                Message="User created successfully",
                Roles=new List<string> { RolesList.User },
                Token=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName=user.UserName,
                RefreshTokenExpiration=DateTime.UtcNow.AddDays(7)
            };
        }


        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _uManage.GetClaimsAsync(user);
            var userRoles = await _uManage.GetRolesAsync(user);
            var rolesCliams = new List<Claim>();

            foreach (var role in userRoles)
                rolesCliams.Add(new Claim(ClaimTypes.Role, role));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }
            .Union(userClaims)
            .Union(rolesCliams);

            var semetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_userJWT.Key));
            var signingCred = new SigningCredentials(semetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken
            (
                issuer: _userJWT.Issuer,
                audience: _userJWT.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: signingCred
            );

            return jwtSecurityToken;
        }

        public async Task<AutherModel> RefreshToken(string token)
        {
            var authModel = new AutherModel();
            var user = await _uManage.Users
                .Include(u => u.RefrshTokens)
                .FirstOrDefaultAsync(u => u.RefrshTokens.Any(t => t.Token == token));

            if (user is null)
            {
                authModel.Message="Invalid Token";
                return authModel;
            }

            var refreshToken = user.RefrshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
            {
                authModel.Message="Inactive Token";
                return authModel;
            }

            refreshToken.RevokedOn=DateTime.UtcNow;

            var newRefreshToken = GenerateRefrshToken();
            user.RefrshTokens.Add(newRefreshToken);
            await _uManage.UpdateAsync(user);

            var jwtSecurityToken = await CreateJwtToken(user);

            authModel.IsAuthenticated=true;
            authModel.Message="Token refreshed successfully";
            authModel.Token=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.UserName = user.UserName;
            var role = await _uManage.GetRolesAsync(user);
            authModel.Roles=role.ToList();
            authModel.RefreshToken=newRefreshToken.Token;
            authModel.RefreshTokenExpiration=newRefreshToken.ExpiresOn;

            return authModel;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _uManage.Users
                .Include(u => u.RefrshTokens)
                .FirstOrDefaultAsync(u => u.RefrshTokens.Any(t => t.Token == token));

            if (user is null) return false;

            var refreshToken = user.RefrshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive) return false;

            refreshToken.RevokedOn=DateTime.UtcNow;
            await _uManage.UpdateAsync(user);

            return true;

        }
        private RefreshToken GenerateRefrshToken()
        {
            var randumNumber = new byte[32];
            var userJWT = new UserJWT();
            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randumNumber);

            return new RefreshToken
            {
                Token=Convert.ToBase64String(randumNumber),
                CreatedOn=DateTime.UtcNow,
                ExpiresOn=DateTime.UtcNow.AddHours(2)
            };
        }

    }
}
