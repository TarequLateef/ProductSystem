namespace Product.Core.DbStructs
{
    public struct UserSchema
    {
        public const string Secure = "Secure";
    }

    public struct UserTables
    {
        public const string Users = "Users";
        public const string Roles = "Roles";
        public const string UserRoles = "UserRoles";
        public const string UserClaims = "UserClaims";
        public const string UserTokens = "UserTokens";
        public const string RoleClaims = "RoleClaims";
    }

    public struct RolesList
    {
        public const string Dev = "Developer";
        public const string Admin = "Administrator";
        public const string Super = "SuperVisor";
        public const string User = "User";
        public string Role { get; private set; }
        public RolesList(Roles? roles)
        {
            switch (roles)
            {
                case Roles.Developer:
                    Role = Dev;
                    break;
                case Roles.Administrator:
                    Role = Admin;
                    break;
                case Roles.SuperVisor:
                    Role = Super;
                    break;
                default:
                    Role = User;
                    break;
            }
        }
    }

    public enum Roles
    {
        Developer, Administrator, SuperVisor, User
    }

    public struct UserCookie
    {
        public const string CookieName = "UidCook";
    }
}
