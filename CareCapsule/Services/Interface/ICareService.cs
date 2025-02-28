namespace Pharmacy.Services.Interface;

public interface ICareService
{
    Task<Result<CareResponse>> AddAsync( CareRequest Request, CancellationToken cancellationToken = default);
    Task<Result<CareResponse>> GetByIdAsynce ( int id, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<CareResponse>>> GetByNameAsynce( string Name, CancellationToken cancellationToken = default);

    Task<Result<IEnumerable<CareResponse>>> GetAll( CancellationToken cancellationToken = default);

}

