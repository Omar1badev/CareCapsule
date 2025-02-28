using SurveyBasket.Abstractions;

namespace Pharmacy.Abstractions.Errors;

public class PharmacyErrors
{
    public static readonly Error Invalidinput = new("Poll.InvalidInputa", "Invalid Poll");
}
