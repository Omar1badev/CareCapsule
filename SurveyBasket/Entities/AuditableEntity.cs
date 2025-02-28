using Microsoft.AspNetCore.Identity;

namespace SurveyBasket.Entities;

public class AuditableEntity
{
    public string CreatedById { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? UpdatedById { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IdentityUser CreatedBy { get; set; } = default!;
    public IdentityUser? UpdatedBy { get; set; }
}
