using Microsoft.AspNetCore.Authorization;

namespace Pharmacy.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PharmaciesController(IPharmacyervice pharmacy) : ControllerBase
{
    private readonly IPharmacyervice pharmacy = pharmacy;

    [HttpGet]
    
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var pharmcies = await pharmacy.GetAllasync(cancellationToken);
        return Ok(pharmcies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByid(int id, CancellationToken cancellationToken)
    {

        var pol = await pharmacy.GetByIdasync(id, cancellationToken);

        return pol.IsSuccess ? Ok(pol.Value) : NotFound(pol.Error);

    }


    [HttpDelete("{Id}")]
    //[Authorize]
    public async Task<IActionResult> Delete([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var c = await pharmacy.Deletesasync(Id, cancellationToken);
        return c.IsSuccess ? NoContent() : BadRequest();
    }
    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> Add([FromBody] PharmacyRequest req, CancellationToken cancellationToken)
    {
        //var polls = pollreq.Adapt<Polls>();
        var Pharmacy = await pharmacy.Addasync(req, cancellationToken);

        return CreatedAtAction(nameof(GetByid), new { Pharmacy.Id }, Pharmacy);

    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] PharmacyRequest request, CancellationToken cancellationToken)
    {
        var c = await pharmacy.Updatesasync(Id, request, cancellationToken);
        return c.IsSuccess ? NoContent() : NotFound(c.Error);
    }


    [HttpGet("with-name{Name}")]
    public async Task<IActionResult> GetByName(string Name, CancellationToken cancellationToken)
    {

        var pol = await pharmacy.GetByNameAsynce(Name, cancellationToken);

        return pol.IsSuccess ? Ok(pol.Value) : NotFound(pol.Error);

    }

}
