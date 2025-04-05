using Microsoft.AspNetCore.Mvc;
using Dalel.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Models.HomeService;

[ApiController]
[Route("api/[controller]")]
public class ServiceProviderSchedulesController : ControllerBase
{
    private readonly ServiceProviderScheduleRepository _repository;

    public ServiceProviderSchedulesController(ServiceProviderScheduleRepository repository)
    {
        _repository = repository;
    }

    // GET: api/ServiceProviderSchedules/provider/{providerId}
    [HttpGet("provider/{providerId}")]
    public async Task<ActionResult<IEnumerable<ServiceProviderSchedule>>> GetByProvider(string providerId)
    {
        var schedules = await _repository.GetSchedulesByProviderAsync(providerId);
        return Ok(schedules);
    }

    // GET: api/ServiceProviderSchedules/availability
    [HttpGet("availability")]
    public async Task<ActionResult<bool>> CheckAvailability(
        [FromQuery] string providerId,
        [FromQuery] DateTime date,
        [FromQuery] TimeOnly time)
    {
        return Ok(await _repository.IsProviderAvailableAsync(providerId, date, time));
    }

    // GET: api/ServiceProviderSchedules
    [HttpGet]
    public ActionResult<IEnumerable<ServiceProviderSchedule>> Get(
        [FromQuery] int pageSize = 4,
        [FromQuery] int pageNumber = 1)
    {
        var schedules = _repository.Get(null, pageSize, pageNumber);
        return Ok(schedules.ToList());
    }

    // GET: api/ServiceProviderSchedules/{id}
    [HttpGet("{id}")]
    public ActionResult<ServiceProviderSchedule> GetById(int id)
    {
        var schedule = _repository.GetList(s => s.Id == id).FirstOrDefault();
        if (schedule == null) return NotFound();
        return schedule;
    }

    // POST: api/ServiceProviderSchedules
    [HttpPost]
    public IActionResult Create(ServiceProviderSchedule schedule)
    {
        _repository.Add(schedule);
        return CreatedAtAction(nameof(GetById), new { id = schedule.Id }, schedule);
    }

    // PUT: api/ServiceProviderSchedules/provider/{providerId}
    [HttpPut("provider/{providerId}")]
    public async Task<IActionResult> UpdateProviderSchedule(
        string providerId,
        [FromBody] IEnumerable<ServiceProviderSchedule> schedules)
    {
        await _repository.UpdateProviderScheduleAsync(providerId, schedules);
        return NoContent();
    }

    // PUT: api/ServiceProviderSchedules/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, ServiceProviderSchedule schedule)
    {
        if (id != schedule.Id) return BadRequest();
        _repository.Update(schedule);
        return NoContent();
    }

    // DELETE: api/ServiceProviderSchedules/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var schedule = _repository.GetList(s => s.Id == id).FirstOrDefault();
        if (schedule == null) return NotFound();

        _repository.Delete(schedule);
        return NoContent();
    }
}