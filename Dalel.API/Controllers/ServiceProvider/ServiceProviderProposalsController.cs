using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models.HomeService;
using Dalel.Repository;

[ApiController]
[Route("api/[controller]")]
public class ServiceProviderProposalsController : ControllerBase
{
    private readonly ServiceProviderProposalService _service;

    public ServiceProviderProposalsController(ServiceProviderProposalService service)
    {
        _service = service;
    }

    // GET: api/ServiceProviderProposals/request/{requestId}
    [HttpGet("request/{requestId}")]
    public async Task<ActionResult<IEnumerable<ServiceProviderPropsal>>> GetByRequest(int requestId)
    {
        var proposals = await _service.GetProposalsByRequestAsync(requestId);
        return Ok(proposals);
    }

    // GET: api/ServiceProviderProposals/provider/{providerId}
    [HttpGet("provider/{providerId}")]
    public async Task<ActionResult<IEnumerable<ServiceProviderPropsal>>> GetByProvider(string providerId)
    {
        var proposals = await _service.GetProposalsByProviderAsync(providerId);
        return Ok(proposals);
    }

    // GET: api/ServiceProviderProposals
    [HttpGet]
    public ActionResult<IEnumerable<ServiceProviderPropsal>> Get(
        [FromQuery] int pageSize = 4,
        [FromQuery] int pageNumber = 1)
    {
        var proposals = _service.GetProposals(pageSize, pageNumber);
        return Ok(proposals);
    }

    // GET: api/ServiceProviderProposals/{id}
    [HttpGet("{id}")]
    public ActionResult<ServiceProviderPropsal> GetById(int id)
    {
        var proposal = _service.GetProposalById(id);
        if (proposal == null) return NotFound();
        return proposal;
    }

    // GET: api/ServiceProviderProposals/{id}/details
    [HttpGet("{id}/details")]
    public async Task<ActionResult<ServiceProviderPropsal>> GetWithDetails(int id)
    {
        var proposal = await _service.GetProposalWithDetailsAsync(id);
        if (proposal == null) return NotFound();
        return proposal;
    }

    // POST: api/ServiceProviderProposals/check
    [HttpPost("check")]
    public async Task<ActionResult<bool>> HasProviderProposed(
        [FromQuery] int requestId,
        [FromQuery] string providerId)
    {
        return await _service.HasProviderProposedAsync(requestId, providerId);
    }

    // POST: api/ServiceProviderProposals
    [HttpPost]
    public IActionResult Create(ServiceProviderPropsal proposal)
    {
        var createdProposal = _service.CreateProposal(proposal);
        return CreatedAtAction(nameof(GetById), new { id = createdProposal.Id }, createdProposal);
    }

    // PUT: api/ServiceProviderProposals/{id}/accept
    [HttpPut("{id}/accept")]
    public async Task<IActionResult> AcceptProposal(int id)
    {
        await _service.AcceptProposalAsync(id);
        return NoContent();
    }

    // PUT: api/ServiceProviderProposals/{id}/reject
    [HttpPut("{id}/reject")]
    public async Task<IActionResult> RejectProposal(int id)
    {
        await _service.RejectProposalAsync(id);
        return NoContent();
    }

    // PUT: api/ServiceProviderProposals/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, ServiceProviderPropsal proposal)
    {
        if (id != proposal.Id) return BadRequest();
        _service.UpdateProposal(proposal);
        return NoContent();
    }

    // DELETE: api/ServiceProviderProposals/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var proposal = _service.GetProposalById(id);
        if (proposal == null) return NotFound();

        _service.DeleteProposal(id);
        return NoContent();
    }
}