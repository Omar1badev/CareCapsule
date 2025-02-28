using SurveyBasket.Abstractions;

namespace Pharmacy.Abstractions.Errors;

public class CareErrors
{
    public static readonly Error Invalidinput = new("Care.InvalidInputa", "Invalid Care");
}
