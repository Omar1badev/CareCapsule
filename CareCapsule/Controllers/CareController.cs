namespace Pharmacy.Controllers;


[Route("api/Pharmacy/[controller]")]
[ApiController]
public class CareController(ICareService care) : ControllerBase
{
    private readonly ICareService care = care;

    [HttpPost("")]
    public async Task<IActionResult> Add( [FromBody] CareRequest request, CancellationToken cancellationToken)
    {
        var result = await care.AddAsync( request, cancellationToken);

        return result.IsSuccess ?
            CreatedAtAction(nameof(GetById), new { result.Value.Id }, result.Value) :
            BadRequest();
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById( int Id, CancellationToken cancellationToken)
    {
        var ge = await care.GetByIdAsynce( Id, cancellationToken);
        return ge.IsSuccess ? Ok(ge.Value) : NotFound(ge.Error);
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAll( CancellationToken cancellationToken)
    {

        var ge = await care.GetAll( cancellationToken);
        return ge.IsSuccess ? Ok(ge.Value) : BadRequest();

    }

    [HttpGet("name:{Name}")]
    public async Task<IActionResult> GetById( string Name, CancellationToken cancellationToken)
    {
        var ge = await care.GetByNameAsynce( Name, cancellationToken);
        return ge.IsSuccess ? Ok(ge.Value) : BadRequest();
    }



}
