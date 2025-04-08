using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.HomeService;

[ApiController]
[Route("api/[controller]")]
public class ServiceProviderSchedulesController : ControllerBase
{
    private readonly ServiceProviderScheduleService _service;

    public ServiceProviderSchedulesController(ServiceProviderScheduleService service)
    {
        _service = service;
    }

    // GET: api/ServiceProviderSchedules/provider/{providerId}
    [HttpGet("provider/{providerId}")]
    public async Task<ActionResult<IEnumerable<ServiceProviderSchedule>>> GetByProvider(string providerId)
    {
        var schedules = await _service.GetSchedulesByProviderAsync(providerId);
        return Ok(schedules);
    }

    // GET: api/ServiceProviderSchedules/availability
    [HttpGet("availability")]
    public async Task<ActionResult<bool>> CheckAvailability(
        [FromQuery] string providerId,
        [FromQuery] DateTime date,
        [FromQuery] TimeOnly time)
    {
        var isAvailable = await _service.IsProviderAvailableAsync(providerId, date, time);
        return Ok(isAvailable);
    }

    // GET: api/ServiceProviderSchedules
    [HttpGet]
    public ActionResult<IEnumerable<ServiceProviderSchedule>> Get(
        [FromQuery] int pageSize = 4,
        [FromQuery] int pageNumber = 1)
    {
        var schedules = _service.GetSchedules(pageSize, pageNumber);
        return Ok(schedules);
    }

    // GET: api/ServiceProviderSchedules/{id}
    [HttpGet("{id}")]
    public ActionResult<ServiceProviderSchedule> GetById(int id)
    {
        var schedule = _service.GetScheduleById(id);
        if (schedule == null) return NotFound();
        return schedule;
    }

    // POST: api/ServiceProviderSchedules
    [HttpPost]
    public IActionResult Create(ServiceProviderSchedule schedule)
    {
        var createdSchedule = _service.CreateSchedule(schedule);
        return CreatedAtAction(nameof(GetById), new { id = createdSchedule.Id }, createdSchedule);
    }

    // PUT: api/ServiceProviderSchedules/provider/{providerId}
    [HttpPut("provider/{providerId}")]
    public async Task<IActionResult> UpdateProviderSchedule(
        string providerId,
        [FromBody] IQueryable<ServiceProviderSchedule> schedules)
    {
        await _service.UpdateProviderScheduleAsync(providerId, schedules);
        return NoContent();
    }

    // PUT: api/ServiceProviderSchedules/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, ServiceProviderSchedule schedule)
    {
        if (id != schedule.Id) return BadRequest();
        _service.UpdateSchedule(schedule);
        return NoContent();
    }

    // DELETE: api/ServiceProviderSchedules/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var schedule = _service.GetScheduleById(id);
        if (schedule == null) return NotFound();

        _service.DeleteSchedule(id);
        return NoContent();
    }
}