using Pharmacy.Entities;

namespace Pharmacy.Services.Implemintation;

public class CareService(ApplicationDbContext context) : ICareService
{
    private readonly ApplicationDbContext context = context;

    public async Task<Result<CareResponse>> AddAsync( CareRequest Request, CancellationToken cancellationToken = default)
    {
       
        var Care = Request.Adapt<Care>();
        


        await context.AddAsync(Care, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success(Care.Adapt<CareResponse>());
    }


    public async Task<Result<IEnumerable<CareResponse>>> GetAll( CancellationToken cancellationToken = default)
    {
        
        var Cares = await context.Care
           // .Where(x => x.PharmacyId == PharmacyId)
            .ProjectToType<CareResponse>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return Result.Success<IEnumerable<CareResponse>>(Cares);
    }


    public async Task<Result<CareResponse>> GetByIdAsynce( int id, CancellationToken cancellationToken = default)
    {
        var care = await context.Care
            .Where(x=> x.Id == id)
            .ProjectToType<CareResponse>()
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        if (care is null)
            return Result.Failure<CareResponse>(CareErrors.Invalidinput);

        return Result.Success(care);

    }

    public async Task<Result<IEnumerable<CareResponse>>> GetByNameAsynce( string Name, CancellationToken cancellationToken = default)
    {
        var care = await context.Care
           .Where(x => x.Name.StartsWith(Name))
           .ProjectToType<CareResponse>()
           .AsNoTracking()
           .ToListAsync(cancellationToken);

       

        return Result.Success<IEnumerable<CareResponse>>(care);
    }
}
