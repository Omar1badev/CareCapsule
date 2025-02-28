namespace Pharmacy.Entities;

public class Care //: AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Brand { get; set; } = string.Empty;
    public int Count { get; set; }

    public ICollection<Pharmacies> Pharmacies { get; set; } = [];

}
