using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dalel.Repository;
using Models.HomeService;

public class ServiceProviderScheduleService
{
    private readonly ServiceProviderScheduleRepository _repository;

    public ServiceProviderScheduleService(ServiceProviderScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IQueryable<ServiceProviderSchedule>> GetSchedulesByProviderAsync(string providerId)
    {
        return (IQueryable<ServiceProviderSchedule>)await _repository.GetSchedulesByProviderAsync(providerId);
    }

    public async Task<bool> IsProviderAvailableAsync(string providerId, DateTime date, TimeOnly time)
    {
        return await _repository.IsProviderAvailableAsync(providerId, date, time);
    }

    public IQueryable<ServiceProviderSchedule> GetSchedules(int pageSize, int pageNumber)
    {
        return (IQueryable<ServiceProviderSchedule>)_repository.Get(null, pageSize, pageNumber).ToList();
    }

    public ServiceProviderSchedule GetScheduleById(int id)
    {
        return _repository.GetList(s => s.Id == id).FirstOrDefault();
    }

    public ServiceProviderSchedule CreateSchedule(ServiceProviderSchedule schedule)
    {
        _repository.Add(schedule);
        return schedule;
    }

    public async Task UpdateProviderScheduleAsync(string providerId, IEnumerable<ServiceProviderSchedule> schedules)
    {
        await _repository.UpdateProviderScheduleAsync(providerId, schedules);
    }

    public void UpdateSchedule(ServiceProviderSchedule schedule)
    {
        _repository.Update(schedule);
    }

    public void DeleteSchedule(int id)
    {
        var schedule = GetScheduleById(id);
        if (schedule != null)
        {
            _repository.Delete(schedule);
        }
    }
}