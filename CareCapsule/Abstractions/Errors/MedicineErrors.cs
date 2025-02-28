using SurveyBasket.Abstractions;

namespace Pharmacy.Abstractions.Errors;

public class MedicineErrors
{
    public static readonly Error Invalidinput = new("MedicineErrors.InvalidInputa", "Invalid MedicineErrors");
}
