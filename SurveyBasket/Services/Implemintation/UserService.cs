
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Pharmacy.Contracts.User;
using Pharmacy.Entities;

namespace Pharmacy.Services.Implemintation;

public class UserService(UserManager<ApplicationUser> manager ) : IUserService
{
    private readonly UserManager<ApplicationUser> manager = manager;

    public async Task<Result<UserProfile>> userprofile (string userId)
    {
        var User = await manager.Users
            .Where(i => i.Id == userId)
            .ProjectToType<UserProfile>()
            .SingleAsync();

        return Result.Success(User);
    }

    public async Task<Result> Updateprofile(string userId , UpdateUserProfileRequest request)
    {
        var user =  await manager.FindByIdAsync(userId);

        user = request.Adapt(user);

        await manager.UpdateAsync(user!);    

        return Result.Success();
    }
}
