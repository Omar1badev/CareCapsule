
namespace Pharmacy.Contracts.PharmacyStanderModel;

public class PharmacyResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public string PhoneNumbers { get; set; } = string.Empty;
    public string WhatsUrl { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string MapsLocation { get; set; } = string.Empty;
    public string WorkTime { get; set; } = " 24 hours ";

    public List<MedicineResponse> Medicines { get; set; } = default!;
    public List<CareResponse> Care { get; set; } = default!;
}
