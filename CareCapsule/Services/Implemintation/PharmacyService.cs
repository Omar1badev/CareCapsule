using Pharmacy.Entities;

namespace Pharmacy.Services.Implemintation;

public class Pharmacyervice(ApplicationDbContext dbContext) : IPharmacyervice
{
    private readonly ApplicationDbContext dbContext = dbContext;

    public async Task<PharmacyResponse> Addasync(PharmacyRequest pharmacy, CancellationToken cancellationToken = default)
    {

        var Pharmacy = pharmacy.Adapt<Pharmacies>();


        await dbContext.Pharmacies.AddAsync(Pharmacy, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Pharmacy.Adapt<PharmacyResponse>();
    }
    public async Task<Result> Deletesasync(int id, CancellationToken cancellationToken = default)
    {
        var p = await dbContext.Pharmacies.FindAsync(id, cancellationToken);
        if (p == null)
            return Result.Failure(PharmacyErrors.Invalidinput);
        dbContext.Pharmacies.Remove(p);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<IEnumerable<PharmacyResponse>> GetAllasync(CancellationToken cancellationToken = default)
    {
        IEnumerable<Pharmacies> pharmacies = await dbContext.Pharmacies
            .Include(c => c.Medicines)
            .Include(t => t.Care)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        var pha = pharmacies.Adapt<IEnumerable<PharmacyResponse>>();
        return pha;
    }

    public async Task<Result<PharmacyResponse>> GetByIdasync(int id, CancellationToken cancellationToken = default)
    {
        var pharmacies = await dbContext.Pharmacies.Include(c => c.Medicines).Include(c => c.Care).SingleOrDefaultAsync(b => b.Id == id, cancellationToken);


        // dbContext.Entry(pharmacies).Collection(b => b.Medicines).LoadAsync(cancellationToken);

        return pharmacies is not null ?
            Result.Success(pharmacies.Adapt<PharmacyResponse>())
            : Result.Failure<PharmacyResponse>(PharmacyErrors.Invalidinput);

    }

    public async Task<Result> Updatesasync(int id, PharmacyRequest pharmacy, CancellationToken cancellationToken = default)
    {
        var pharmacy1 = await dbContext.Pharmacies.FindAsync(id);
        if (pharmacy1 == null)
            return Result.Failure(PharmacyErrors.Invalidinput);
        pharmacy1.PhoneNumbers = pharmacy.PhoneNumbers;
        pharmacy1.WhatsUrl = pharmacy.WhatsUrl;
        pharmacy1.MapsLocation = pharmacy.MapsLocation;
        pharmacy1.Location = pharmacy.Location;

        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result<IEnumerable<PharmacyResponse>>> GetByNameAsynce(string Name, CancellationToken cancellationToken = default)
    {
        var pharmacies = await dbContext.Pharmacies
           .Include(c => c.Medicines)
           .Include(c => c.Care)
           .Where(x => x.Name.StartsWith(Name))
           .ProjectToType<PharmacyResponse>()
           .AsNoTracking()
           .ToListAsync(cancellationToken);



        return Result.Success<IEnumerable<PharmacyResponse>>(pharmacies);

    }
}
