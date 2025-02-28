using Pharmacy.Entities;

namespace Pharmacy.Services.Implemintation;

public class MedicineService(ApplicationDbContext context) : IMedicineService
{
    public async Task<Result<MedicineResponse>> AddAsync( MedicineRequest Request, CancellationToken cancellationToken = default)
    {
        var Medicine = Request.Adapt<Medicine>();

        
        await context.AddAsync(Medicine, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success(Medicine.Adapt<MedicineResponse>());
    }


    public async Task<Result<IEnumerable<MedicineResponse>>> GetAll(CancellationToken cancellationToken = default)
    {
        var Cares = await context.Medicine.AsNoTracking().ProjectToType<MedicineResponse>().ToListAsync(cancellationToken);

        return Result.Success<IEnumerable<MedicineResponse>>(Cares);
    }


    public async Task<Result<MedicineResponse>> GetByIdAsynce( int id, CancellationToken cancellationToken = default)
    {
        var care = await context.Medicine
            .Where(x=> x.Id == id)
            .ProjectToType<MedicineResponse>()
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        if (care is null)
            return Result.Failure<MedicineResponse>(MedicineErrors.Invalidinput);

        return Result.Success(care);

    }

    public async Task<Result<IEnumerable<MedicineResponse>>> GetByNameAsynce(string Name, CancellationToken cancellationToken = default)
    {
        var care = await context.Medicine
           .Where(x => x.Name.StartsWith(Name))
           .ProjectToType<MedicineResponse>()
           .AsNoTracking()
           .ToListAsync(cancellationToken);

   

        return Result.Success<IEnumerable<MedicineResponse>>(care);
    }
}

