namespace Pharmacy.Services.Interface;

public interface IMedicineService
{
    Task<Result<MedicineResponse>> AddAsync( MedicineRequest Request, CancellationToken cancellationToken = default);
    Task<Result<MedicineResponse>> GetByIdAsynce( int id, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<MedicineResponse>>> GetByNameAsynce( string Name, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<MedicineResponse>>> GetAll(CancellationToken cancellationToken = default);
}
