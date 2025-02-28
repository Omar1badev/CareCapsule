namespace Pharmacy.Contracts.User;

public record UpdateUserProfileRequest
(
    string Name,
    string ImageUrl
);
