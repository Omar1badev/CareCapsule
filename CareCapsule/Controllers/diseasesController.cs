namespace Pharmacy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiseasesController(IDiseasesService service) : ControllerBase
{
    private readonly IDiseasesService service = service;

    [HttpGet("With Id : {Id}")]
    public async Task<IActionResult> GetById( int Id, CancellationToken cancellationToken)
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

    [HttpGet("With name : {Name}")]
    public async Task<IActionResult> GetById(string Name, CancellationToken cancellationToken)
    {
        var ge = await service.GetByNameAsynce(Name, cancellationToken);
        return ge.IsSuccess ? Ok(ge.Value) : BadRequest();
    }
}
