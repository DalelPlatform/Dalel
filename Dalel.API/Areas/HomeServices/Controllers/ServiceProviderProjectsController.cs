using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models.HomeService;
using Dalel.Services;

[ApiController]
[Route("api/[controller]")]
public class ServiceProviderProjectsController : ControllerBase
{
    private readonly HomeServicesService _service;

    public ServiceProviderProjectsController(HomeServicesService service)
    {
        _service = service;
    }

    // GET: api/ServiceProviderProjects/provider/{providerId}
    [HttpGet("provider/{providerId}")]
    public async Task<ActionResult> GetByProvider(string providerId)
    {
        var res = await _service.GetProjectsByProviderAsync(providerId);
        return new JsonResult(res);
    }

    // GET: api/ServiceProviderProjects
    [HttpGet]
    public ActionResult<IQueryable<ServiceProviderProject>> Get(
        [FromQuery] int pageSize = 4,
        [FromQuery] int pageNumber = 1)
    {
        var projects = _service.GetProjects(pageSize, pageNumber);
        return Ok(projects);
    }

    // GET: api/ServiceProviderProjects/{id}
    [HttpGet("{id}")]
    public ActionResult<ServiceProviderProject> GetById(int id)
    {
        var project = _service.GetProjectById(id);
        if (project == null) return NotFound();
        return project;
    }

    // POST: api/ServiceProviderProjects
    [HttpPost]
    public IActionResult CreateProject(
        [FromBody] ServiceProviderProject project,
        [FromQuery] string imagePath = null)
    {
        var createdProject = _service.CreateProject(project, imagePath);
        return CreatedAtAction(nameof(GetById), new { id = createdProject.Id }, createdProject);
    }

    // PUT: api/ServiceProviderProjects/{id}/image
    [HttpPut("{id}/image")]
    public async Task<IActionResult> UpdateImage(int id, [FromQuery] string newImagePath)
    {
        await _service.UpdateProjectImageAsync(id, newImagePath);
        return NoContent();
    }

    // PUT: api/ServiceProviderProjects/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, ServiceProviderProject project)
    {
        if (id != project.Id) return BadRequest();
        _service.UpdateProject(project);
        return NoContent();
    }

    // DELETE: api/ServiceProviderProjects/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var project = _service.GetProjectById(id);
        if (project == null) return NotFound();

        _service.DeleteProject(id);
        return NoContent();
    }
}