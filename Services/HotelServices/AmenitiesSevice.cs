using Dalel.Repository.GenericHotelRepo;  
using Dalel.Repository.Hotel.Non_GenericRepository; // For ServiceRepository
using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Dalel.Services.HotelService
{
    public class AmenitiesService
    {
        private readonly ServiceRepository _serviceRepository;

        public AmenitiesService(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // Bulk insert a list of Service entities.
        
        public async Task<ServiceResult> BulkInsertAsync(List<Service> services)
        {
            try
            {
                await _serviceRepository.BulkInsertServicesAsync(services);
                await _serviceRepository.SaveAsync();
                return ServiceResult.SuccessResult("Bulk insert completed successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Bulk insert failed: " + ex.Message);
            }
        }

        
        // Bulk update a list of Service entities.
        
        public async Task<ServiceResult> BulkUpdateAsync(List<Service> services)
        {
            try
            {
                await _serviceRepository.BulkUpdateServicesAsync(services);
                await _serviceRepository.SaveAsync();
                return ServiceResult.SuccessResult("Bulk update completed successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Bulk update failed: " + ex.Message);
            }
        }

    
        // Bulk update the status of a list of Service entities.
    
        public async Task<ServiceResult> BulkUpdateStatusAsync(List<Service> services)
        {
            try
            {
                await _serviceRepository.BulkUpdateServicesStatusAsync(services);
                await _serviceRepository.SaveAsync();
                return ServiceResult.SuccessResult("Bulk status update completed successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Bulk status update failed: " + ex.Message);
            }
        }

        // Retrieve all Service entities.
        
        public async Task<ServiceResult<IEnumerable<Service>>> GetAllAsync()
        {
            try
            {
                var list = await _serviceRepository.GetAllAsync();
                return ServiceResult<IEnumerable<Service>>.SuccessResult(list, "Retrieved all services successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<Service>>.FailureResult("Error retrieving services: " + ex.Message);
            }
        }

    
        // Retrieve a Service by its ID.
      
        public async Task<ServiceResult<Service>> GetByIdAsync(int id)
        {
            try
            {
                var service = await _serviceRepository.GetByIdAsync(id);
                if (service == null)
                    return ServiceResult<Service>.FailureResult("Service not found.");
                return ServiceResult<Service>.SuccessResult(service, "Service retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Service>.FailureResult("Error retrieving service: " + ex.Message);
            }
        }
    }
}
