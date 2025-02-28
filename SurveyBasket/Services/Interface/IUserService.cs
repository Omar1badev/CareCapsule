using Pharmacy.Contracts.User;

namespace Pharmacy.Services.Interface;

public interface IUserService
{
    Task<Result<UserProfile>> userprofile(string userId);

     Task<Result> Updateprofile(string userId, UpdateUserProfileRequest request);
}
