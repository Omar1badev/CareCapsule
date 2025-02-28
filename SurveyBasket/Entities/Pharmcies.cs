namespace Pharmacy.Entities;

public class Pharmacies //: AuditableEntity
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public string PhoneNumbers { get; set; } = string.Empty;
    public string WhatsUrl { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string MapsLocation { get; set; } = string.Empty;
    public string WorkTime { get; set; } = " 24 hours ";

    public ICollection<Medicine> Medicines { get; set; } = [];
    public ICollection<Care> Care { get; set; } = [];

}
