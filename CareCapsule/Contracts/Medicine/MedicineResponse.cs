namespace Pharmacy.Contracts.Medicine;

public class MedicineResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public int Price { get; set; }
    public string EffectiveSubstance { get; set; } = string.Empty;
    public int Count { get; set; }
}
