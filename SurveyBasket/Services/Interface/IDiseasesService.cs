namespace Pharmacy.Services.Interface;

public interface IDiseasesService
{
    Task<Result<DiseasesResponse>> GetByIdAsynce(int id, CancellationToken cancellationToken = default);
    Task<Result<DiseasesResponse>> GetByNameAsynce(string Name, CancellationToken cancellationToken = default);

    Task<Result<IEnumerable<DiseasesResponse>>> GetAll(CancellationToken cancellationToken = default);
}
