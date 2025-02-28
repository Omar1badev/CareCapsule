using Microsoft.AspNetCore.Identity;

namespace Pharmacy.Entities;

public class ApplicationUser : IdentityUser
{
    string Name { get; set; } = string.Empty;
}
