namespace Pharmacy.Services.Implemintation;

public class DiseasesService(ApplicationDbContext context) : IDiseasesService
{
    private readonly ApplicationDbContext context = context;

    public async Task<Result<IEnumerable<DiseasesResponse>>> GetAll(CancellationToken cancellationToken = default)
    {
        var Diseases = await context.Diseases
            .ProjectToType<DiseasesResponse>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return Result.Success<IEnumerable<DiseasesResponse>>(Diseases);
    }

    public async Task<Result<DiseasesResponse>> GetByIdAsynce(int id, CancellationToken cancellationToken = default)
    {
        var Diseases = await context.Diseases
            .Where(x=>x.Id == id)
            .ProjectToType<DiseasesResponse>()
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        if (Diseases is null)
            return Result.Failure<DiseasesResponse>(MedicineErrors.Invalidinput);

        return Result.Success(Diseases);
    }

    public async Task<Result<DiseasesResponse>> GetByNameAsynce(string Name, CancellationToken cancellationToken = default)
    {
        var Diseases = await context.Diseases
                   .Where(x=>x.Name == Name)
                   .ProjectToType<DiseasesResponse>()
                   .AsNoTracking()
                   .SingleOrDefaultAsync(cancellationToken);

        if (Diseases is null)
            return Result.Failure<DiseasesResponse>(CareErrors.Invalidinput);

        return Result.Success(Diseases);
    }
}
