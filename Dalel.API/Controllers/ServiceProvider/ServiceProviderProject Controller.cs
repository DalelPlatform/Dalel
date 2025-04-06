using Microsoft.AspNetCore.Mvc;
using Dalel.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Models.HomeService;

[ApiController]
[Route("api/[controller]")]
public class ServiceProviderProjectsController : ControllerBase
{
    private readonly ServiceProviderProjectRepository _repository;

    public ServiceProviderProjectsController(ServiceProviderProjectRepository repository)
    {
        _repository = repository;
    }

    // GET: api/ServiceProviderProjects/provider/{providerId}
    [HttpGet("provider/{providerId}")]
    public async Task<ActionResult> GetByProvider(string providerId)
    {
        var res = await _repository.GetProjectsByProviderAsync(providerId);
        return new JsonResult(res);
    }

    // GET: api/ServiceProviderProjects
    [HttpGet]
    public ActionResult<IEnumerable<ServiceProviderProject>> Get(
        [FromQuery] int pageSize = 4,
        [FromQuery] int pageNumber = 1)
    {
        var projects = _repository.Get(null, pageSize, pageNumber);
        return Ok(projects.ToList());
    }

    // GET: api/ServiceProviderProjects/{id}
    [HttpGet("{id}")]
    public ActionResult<ServiceProviderProject> GetById(int id)
    {
        var project = _repository.GetList(p => p.Id == id).FirstOrDefault();
        if (project == null) return NotFound();
        return project;
    }

    // POST: api/ServiceProviderProjects
    [HttpPost]
    public IActionResult CreateProject(
        [FromBody] ServiceProviderProject project,
        [FromQuery] string imagePath = null)
    {
        if (!string.IsNullOrEmpty(imagePath))
        {
            project.Image = imagePath;
        }

        _repository.Add(project);
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    // PUT: api/ServiceProviderProjects/{id}/image
    [HttpPut("{id}/image")]
    public async Task<IActionResult> UpdateImage(int id, [FromQuery] string newImagePath)
    {
        await _repository.UpdateProjectImageAsync(id, newImagePath);
        return NoContent();
    }

    // PUT: api/ServiceProviderProjects/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, ServiceProviderProject project)
    {
        if (id != project.Id) return BadRequest();
        _repository.Update(project);
        return NoContent();
    }

    // DELETE: api/ServiceProviderProjects/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var project = _repository.GetList(p => p.Id == id).FirstOrDefault();
        if (project == null) return NotFound();

        _repository.Delete(project);
        return NoContent();
    }
}