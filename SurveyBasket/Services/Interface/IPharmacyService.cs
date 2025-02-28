namespace Pharmacy.Services.Interface;

public interface IPharmacyervice
{
    Task<Result<PharmacyResponse>> GetByIdasync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<PharmacyResponse>> GetAllasync(CancellationToken cancellationToken = default);
    Task<PharmacyResponse> Addasync(PharmacyRequest pharmacy, CancellationToken cancellationToken = default);
    Task<Result> Deletesasync(int id, CancellationToken cancellationToken = default);
    Task<Result> Updatesasync(int id, PharmacyRequest pharmacy, CancellationToken cancellationToken = default);

     Task<Result<IEnumerable<PharmacyResponse>>> GetByNameAsynce(string name, CancellationToken cancellationToken = default);

    //Task<Result> revercpublishpollasync(int id, CancellationToken cancellationToken = default);
    // bool PollStatue (int id);

}
