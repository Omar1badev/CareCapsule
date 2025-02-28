namespace Pharmacy.Controllers;


[Route("api/Pharmacy/[controller]")]
[ApiController]
public class Medicine(IMedicineService service) : ControllerBase
{
    private readonly IMedicineService service = service;

    [HttpPost]
    public async Task<IActionResult> Add( [FromBody] MedicineRequest request, CancellationToken cancellationToken)
    {
        var result = await service.AddAsync( request, cancellationToken);

        return result.IsSuccess ?
            CreatedAtAction(nameof(GetById), new {  result.Value.Id }, result.Value) :
            BadRequest();
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
    {
        var ge = await service.GetByIdAsynce( Id, cancellationToken);
        return ge.IsSuccess ? Ok(ge.Value) : NotFound(ge.Error);
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAll( CancellationToken cancellationToken)
    {

        var ge = await service.GetAll(cancellationToken);
        return ge.IsSuccess ? Ok(ge.Value) : BadRequest();

    }

    [HttpGet("name:{Name}")]
    public async Task<IActionResult> GetById( string Name, CancellationToken cancellationToken)
    {
        var ge = await service.GetByNameAsynce( Name, cancellationToken);
        return ge.IsSuccess ? Ok(ge.Value) : BadRequest();
    }

}
