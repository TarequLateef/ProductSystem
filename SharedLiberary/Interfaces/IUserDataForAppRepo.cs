
using SharedLiberary.Models.UserManagment;

namespace SharedLiberary.Interfaces
{
    public interface IUserDataForAppRepo : IOperationRepository<AutherData>
    {
        Task<AutherData> GetUserData(string lID);
    }
}
