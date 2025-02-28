namespace Pharmacy.Contracts.Care;

public class CareRequest
{
  
    public string Name { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Brand { get; set; } = string.Empty;
    public int Count { get; set; }

}
