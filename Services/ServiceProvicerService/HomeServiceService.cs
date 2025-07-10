using Dalel.Extensions;
using Dalel.Repository;
using Dalel.Repository.HomeServices;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeServices;
using Dalel.ViewModels.HomeServices.CategoryServices;
using Dalel.ViewModels.HomeServices.ServiceNotification;
using Dalel.ViewModels.HomeServices.ServiceProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Enums;
using Models.HomeService;
using Models.User;
using System;
using System.Linq;
using Utilities;

namespace Dalel.Services
{
    public class HomeServiceService
    {
        private readonly ServiceRequestRepository _serviceRequestRepository;
        private readonly ServiceQuariesRepository _serviceQuariesRepository;
        private readonly ServiceProviderScheduleRepository _serviceProviderScheduleRepository;
        private readonly ServiceProviderPropsalRepository _serviceProviderProposalRepository;
        private readonly ServiceProviderProjectRepository _serviceProviderProjectRepository;
        private readonly CategoryServicesRepository _categoryServicesRepository;
        private readonly ServiceProviderReviewRepository _serviceProviderReviewRepository;
        private readonly ServiceProviderPaymentRepository _serviceProviderPaymentRepository;
        private readonly ServiceProviderRepository _serviceProviderRepository;
        private readonly ClientRepository _clientRepository;
        private UploadMedia uploader;
        private readonly ServiceNotificationRepository _serviceNotificationRepository;

        public HomeServiceService(
            ServiceRequestRepository serviceRequestRepository,
            ServiceQuariesRepository serviceQuariesRepository,
            ServiceProviderScheduleRepository serviceProviderScheduleRepository,
            ServiceProviderPropsalRepository serviceProviderProposalRepository,
            ServiceProviderProjectRepository serviceProviderProjectRepository,
            CategoryServicesRepository categoryServicesRepository,
            ServiceProviderReviewRepository serviceProviderReviewRepository,
            ServiceProviderPaymentRepository serviceProviderPaymentRepository,
            ServiceProviderRepository serviceProviderRepository,
            ClientRepository clientRepository,
            ServiceNotificationRepository serviceNotificationRepository,
            UploadMedia uploader)
        {
            _serviceRequestRepository = serviceRequestRepository;
            _serviceQuariesRepository = serviceQuariesRepository;
            _serviceProviderScheduleRepository = serviceProviderScheduleRepository;
            _serviceProviderProposalRepository = serviceProviderProposalRepository;
            _serviceProviderProjectRepository = serviceProviderProjectRepository;
            _categoryServicesRepository = categoryServicesRepository;
            _serviceProviderReviewRepository = serviceProviderReviewRepository;
            _serviceProviderPaymentRepository = serviceProviderPaymentRepository;
            _serviceProviderRepository = serviceProviderRepository;
            _clientRepository = clientRepository;
            _serviceNotificationRepository = serviceNotificationRepository;
            this.uploader = uploader;
        }
        #region Service Request
        public ServiceResult<ServiceRequestDetailsVM> CreateServiceRequest(AddServiceRequestVM vm)
        {
            try
            {
                var entity = vm.ToModel();

                // Check if the client exists
                if (!_clientRepository.GetList(c => c.UserId == entity.ClientId).Any())
                    return ServiceResult<ServiceRequestDetailsVM>.FailureResult("Client not found");

                // Check if the category exists
                if (!_categoryServicesRepository.GetList(c => c.Id == entity.CategoryServicesId).Any())
                    return ServiceResult<ServiceRequestDetailsVM>.FailureResult("Category not found");
                vm.Imagepath = uploader.addimage(vm.Image);
                

                _serviceRequestRepository.Add(entity);
                _serviceRequestRepository.Save(); // Save changes to the database

                return ServiceResult<ServiceRequestDetailsVM>.SuccessResult(
                    entity.ToDetailsViewModel(),
                    "Request created successfully");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceRequestDetailsVM>.FailureResult(
                    $"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>> GetRequestsByCategory(
            int categoryId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (categoryId <= 0)
                    return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Category ID must be greater than zero.");
                var totalCount = _serviceRequestRepository.GetRequestsByCategory(categoryId).Count();
                var requests = _serviceRequestRepository.GetRequestsByCategory(categoryId);
                var data = requests.ToList();
                var paginationResult = new PaginationViewModel<ServiceRequestDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.SuccessResult(paginationResult, "Requests retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>> GetAcceptedRequests(
            int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                var totalCount = _serviceRequestRepository.GetAcceptedRequests().Count();
                var requests = _serviceRequestRepository.GetAcceptedRequests();
                var data = requests.ToList();
                var paginationResult = new PaginationViewModel<ServiceRequestDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.SuccessResult(paginationResult, "Accepted requests retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>> GetPendingRequests(
            int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                var totalCount = _serviceRequestRepository.GetPendingRequests().Count();
                var requests = _serviceRequestRepository.GetPendingRequests();
                var data = requests.ToList();
                var paginationResult = new PaginationViewModel<ServiceRequestDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.SuccessResult(paginationResult, "Pending requests retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>> GetCompletedRequests(
            int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                var totalCount = _serviceRequestRepository.GetCompletedRequests().Count();
                var requests = _serviceRequestRepository.GetCompletedRequests();
                var data = requests.ToList();
                var paginationResult = new PaginationViewModel<ServiceRequestDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.SuccessResult(paginationResult, "Completed requests retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>> GetRejectedRequests(
            int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                var totalCount = _serviceRequestRepository.GetRejectedRequests().Count();
                var requests = _serviceRequestRepository.GetRejectedRequests();
                var data = requests.ToList();
                var paginationResult = new PaginationViewModel<ServiceRequestDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.SuccessResult(paginationResult, "Rejected requests retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }




        //public ServiceResult<ServiceRequestDetailsVM> CreateServiceRequest([FromForm] AddServiceRequestVM vm)
        //{
        //    try
        //    {
        //        if (vm == null)
        //            return ServiceResult<ServiceRequestDetailsVM>.FailureResult("Request data cannot be null");
        //        if (string.IsNullOrWhiteSpace(vm.ClientId))GetRequestsByCategory
        //            return ServiceResult<ServiceRequestDetailsVM>.FailureResult("Client ID cannot be null or empty");
        //        if (!Guid.TryParse(vm.ClientId, out _))
        //            return ServiceResult<ServiceRequestDetailsVM>.FailureResult("Invalid Client ID format");
        //        if (vm.CategoryServicesId <= 0)
        //            return ServiceResult<ServiceRequestDetailsVM>.FailureResult("Invalid Category ID");

        //        var model = vm.ToModel();
        //        _serviceRequestRepository.Add(model);
        //        _serviceRequestRepository.Save();
        //        return ServiceResult<ServiceRequestDetailsVM>.SuccessResult(
        //            model.ToDetailsViewModel(),
        //            "Service request created successfully");
        //    }

        //    catch (Exception ex)
        //    {
        //        return ServiceResult<ServiceRequestDetailsVM>.FailureResult($"Error creating service request: {ex.Message}");
        //    }
        //}

        public ServiceResult<ServiceRequestDetailsVM> GetServiceRequestById(int requestId)
        {
            try
            {
                var request = _serviceRequestRepository.GetRequestWithDetails(requestId);
                if (request == null)
                    return ServiceResult<ServiceRequestDetailsVM>.FailureResult("Service request not found.");

                return ServiceResult<ServiceRequestDetailsVM>.SuccessResult(request.ToDetailsViewModel(), "Service request retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceRequestDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>> GetRequestsByClient(
            string clientId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(clientId))
                    return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Client ID cannot be null or empty.");

                var totalCount = _serviceRequestRepository.GetRequestsByClient(clientId,pageSize).Count();
                var requests = _serviceRequestRepository.GetRequestsByClient(clientId,pageSize);
                var data = requests.Select(r => r.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceRequestDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.SuccessResult(paginationResult, "Requests retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>> GetRequestsByStatus(
            RequestStatus status, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                // Get the total count of requests for this status
                var totalCount = _serviceRequestRepository.GetRequestsByStatus(status,pageSize).Count();
                // Get the paginated subset
                var requests = _serviceRequestRepository.GetRequestsByStatus(status,pageSize);
                var data = requests.Select(r => r.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceRequestDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.SuccessResult(paginationResult, "Requests retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult UpdateServiceRequest(int requestId, [FromForm] AddServiceRequestVM vm)
        {
            try
            {
                var request = _serviceRequestRepository.GetRequestWithDetails(requestId);
                if (request == null)
                    return ServiceResult.FailureResult("Service request not found.");

                var updatedRequest = vm.ToModel();
                updatedRequest.Id = requestId;
                updatedRequest.ClientId = request.ClientId;
                _serviceRequestRepository.Update(updatedRequest);
                return ServiceResult.SuccessResult("Service request updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>> SearchServiceRequest(
            string? Title = "",
            string? Description = null,
            string? Address = null,
            int? CategoryId = null,
            string sortBy = "Date",
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            try
            {
                var providers = _serviceRequestRepository.GetList();

                if (!string.IsNullOrEmpty(Title))
                {
                    string loweredTitle = Title.ToLower();
                    providers = providers.Where(p => p.Title.ToLower().Contains(loweredTitle));
                }
                if (!string.IsNullOrEmpty(Description))
                {
                    string loweredDescription = Description.ToLower();
                    providers = providers.Where(p => p.Description.ToLower().Contains(loweredDescription));
                }
                if (!string.IsNullOrEmpty(Address))
                {
                    string lowerAddress = Address.ToLower();
                    providers = providers.Where(p => p.Address.ToLower().Contains(lowerAddress));
                }
                if (CategoryId.HasValue && CategoryId > 0)
                {
                    providers = providers.Where(p => p.CategoryServicesId == CategoryId.Value);
                }


                switch (sortBy)
                {
                    case "Date":
                        providers = descending ? providers.OrderByDescending(p => p.Date) : providers.OrderBy(p => p.Date);
                        break;
                    //case "averagerating":
                    //    providers = descending ? providers.OrderByDescending(p => p.Propsals.) : providers.OrderBy(p => p.AverageRating);
                    //    break;
                    default:
                        providers = providers.OrderBy(p => p.Date);
                        break;
                }

                var totalCount = providers.Count();
                var paginatedProviders = providers
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var data = paginatedProviders.Select(p => p.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceRequestDetailsVM>
                {
                    Data = data,
                    PageNumber = pageIndex,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.SuccessResult(paginationResult, "Service providers retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceRequestDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult DeleteServiceRequest(int requestId)
        {
            try
            {
                if (requestId <= 0)
                    return ServiceResult.FailureResult("Request ID must be greater than zero.");

                var request = _serviceRequestRepository.GetById(requestId);
                if (request == null)
                    return ServiceResult.FailureResult("Service request not found.");

                _serviceRequestRepository.Delete(request);
                _serviceRequestRepository.Save();

                return ServiceResult.SuccessResult("Service request deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        #endregion

        #region ServiceQuaries

        public ServiceResult<ServiceQuariesDetailsVM> CreateServiceQuery([FromForm] AddServiceQuariesVM vm)
        {
            try
            {
                var query = vm.ToModel();
                if (string.IsNullOrEmpty(query.ClientId))
                    return ServiceResult<ServiceQuariesDetailsVM>.FailureResult("Client ID cannot be null or empty.");
                if (query.CategoryServicesId <= 0)
                    return ServiceResult<ServiceQuariesDetailsVM>.FailureResult("Category ID must be greater than zero.");

                _serviceQuariesRepository.Add(query);
                _serviceQuariesRepository.Save();
                return ServiceResult<ServiceQuariesDetailsVM>.SuccessResult(query.ToDetailsViewModel(), "Service query created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceQuariesDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>> GetQueriesByCategory(
            int categoryId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (categoryId <= 0)
                    return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.FailureResult("Category ID must be greater than zero.");

                var totalCount = _serviceQuariesRepository.GetQueriesByCategory(categoryId).Count();
                var queries = _serviceQuariesRepository.GetQueriesByCategory(categoryId);
                var data = queries.Select(q => q.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceQuariesDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.SuccessResult(paginationResult, "Queries retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>> GetQueriesByClient(
            string clientId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(clientId))
                    return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.FailureResult("Client ID cannot be null or empty.");

                var totalCount = _serviceQuariesRepository.GetQueriesByClient(clientId).Count();
                var queries = _serviceQuariesRepository.GetQueriesByClient(clientId);
                var data = queries.Select(q => q.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceQuariesDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.SuccessResult(paginationResult, "Queries retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>> GetQueriesByProvider(
            string providerId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(providerId))
                    return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.FailureResult("Provider ID cannot be null or empty.");

                var totalCount = _serviceQuariesRepository.GetQueriesByProvider(providerId).Count();
                var queries = _serviceQuariesRepository.GetQueriesByProvider(providerId);
                var data = queries.Select(q => q.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceQuariesDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.SuccessResult(paginationResult, "Queries retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }



        public ServiceResult<ServiceQuariesDetailsVM> GetQueryById(int queryId)
        {
            try
            {
                var query = _serviceQuariesRepository.GetQueryById(queryId);
                if (query == null)
                    return ServiceResult<ServiceQuariesDetailsVM>.FailureResult("Query not found.");

                return ServiceResult<ServiceQuariesDetailsVM>.SuccessResult(query.ToDetailsViewModel(), "Query retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceQuariesDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult UpdateServiceQuery(int queryId, [FromForm] AddServiceQuariesVM vm)
        {
            try
            {
                var query = _serviceQuariesRepository.GetQueryById(queryId);
                if (query == null)
                    return ServiceResult.FailureResult("Service query not found.");

                var updatedQuery = vm.ToModel();
                updatedQuery.Id = queryId;
                updatedQuery.ClientId = query.ClientId;
                updatedQuery.ServiceProviderId = query.ServiceProviderId; 
                _serviceQuariesRepository.Update(updatedQuery);
                return ServiceResult.SuccessResult("Service query updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }


        public ServiceResult DeleteServiceQuery(int queryId)
        {
            try
            {
                if (queryId <= 0)
                    return ServiceResult.FailureResult("Query ID must be greater than zero.");

                var query = _serviceQuariesRepository.GetById(queryId);
                if (query == null)
                    return ServiceResult.FailureResult("Service query not found.");

                _serviceQuariesRepository.Delete(query);
                _serviceQuariesRepository.Save();

                return ServiceResult.SuccessResult("Service query deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        #endregion

        #region ServiceProviderSchedule

        public ServiceResult<PaginationViewModel<ServiceProviderScheduleDetailsVM>> GetSchedulesByProvider(
            string providerId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(providerId))
                    return ServiceResult<PaginationViewModel<ServiceProviderScheduleDetailsVM>>.FailureResult("Provider ID cannot be null or empty.");

                // Get the total count of schedules for this ServiceProvider
                var totalCount = _serviceProviderScheduleRepository.GetSchedulesByProvider(providerId).Count();
                // Get the paginated subset
                var schedules = _serviceProviderScheduleRepository.GetSchedulesByProvider(providerId);
                var data = schedules.Select(s => s.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceProviderScheduleDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceProviderScheduleDetailsVM>>.SuccessResult(paginationResult, "Schedules retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceProviderScheduleDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<bool> IsProviderAvailable(string providerId, DateTime date, TimeOnly time)
        {
            try
            {
                if (string.IsNullOrEmpty(providerId))
                    return ServiceResult<bool>.FailureResult("Provider ID cannot be null or empty.");
                if (date == default)
                    return ServiceResult<bool>.FailureResult("Date cannot be default.");
                if (time == default)
                    return ServiceResult<bool>.FailureResult("Time cannot be default.");

                var isAvailable = _serviceProviderScheduleRepository.IsProviderAvailable(providerId, date, time);
                return ServiceResult<bool>.SuccessResult(isAvailable, isAvailable ? "Provider is available." : "Provider is not available.");
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult AddProviderSchedule(AddServiceProviderScheduleVM vm)
        {
            try
            {
                if (string.IsNullOrEmpty(vm.ServiceProviderId))
                    return ServiceResult.FailureResult("Provider ID cannot be null or empty.");
                if (vm.Schedules == null || !vm.Schedules.Any())
                    return ServiceResult.FailureResult("Schedules cannot be null or empty.");

                var schedules = vm.Schedules.Select(s => s.ToModel(vm.ServiceProviderId)).AsQueryable();
                foreach (var schedule in schedules)
                {
                    if (schedule.AvailableTo <= schedule.AvailableFrom)
                        return ServiceResult.FailureResult("AvailableTo must be greater than AvailableFrom.");
                }

                _serviceProviderScheduleRepository.AddSchedule(schedules);
                _serviceProviderScheduleRepository.Save();
                return ServiceResult.SuccessResult("Provider schedules updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult UpdateProviderSchedule([FromForm] AddServiceProviderScheduleVM vm)
        {
            try
            {
                if (string.IsNullOrEmpty(vm.ServiceProviderId))
                    return ServiceResult.FailureResult("Provider ID cannot be null or empty.");
                if (vm.Schedules == null || !vm.Schedules.Any())
                    return ServiceResult.FailureResult("Schedules cannot be null or empty.");

                var schedules = vm.Schedules.Select(s => s.ToModel(vm.ServiceProviderId)).AsQueryable(); 
                foreach (var schedule in schedules)
                {
                    if (schedule.AvailableTo <= schedule.AvailableFrom)
                        return ServiceResult.FailureResult("AvailableTo must be greater than AvailableFrom.");
                }

                _serviceProviderScheduleRepository.UpdateProviderSchedule(vm.ServiceProviderId, schedules);
                _serviceProviderScheduleRepository.Save();
                return ServiceResult.SuccessResult("Provider schedules updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult DeleteProviderSchedule(string providerId, DateTime date)
        {
            try
            {
                if (string.IsNullOrEmpty(providerId))
                    return ServiceResult.FailureResult("Provider ID cannot be null or empty.");
                if (date == default)
                    return ServiceResult.FailureResult("Date cannot be default.");

                var success = _serviceProviderScheduleRepository.DeleteSchedule(providerId, date);
                if (!success)
                    return ServiceResult.FailureResult("Schedule not found.");

                return ServiceResult.SuccessResult("Schedule deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        #endregion

        #region ServiceProviderProposal

        public ServiceResult<ServiceProviderProposalDetailsVM> CreateProposal([FromForm] AddServiceProviderProposalVM vm)
        {
            try
            {

                var proposal = vm.ToModel();
                if (proposal.SuggestedPrice <= 0)
                    return ServiceResult<ServiceProviderProposalDetailsVM>.FailureResult("Suggested price must be greater than zero.");
                if (string.IsNullOrEmpty(proposal.Description))
                    return ServiceResult<ServiceProviderProposalDetailsVM>.FailureResult("Description cannot be null or empty.");

                var exists = _serviceProviderProposalRepository.HasProviderProposed(proposal.ServiceRequestId, proposal.ServiceProviderId);
                if (exists)
                    return ServiceResult<ServiceProviderProposalDetailsVM>.FailureResult("Provider has already proposed for this request.");

                _serviceProviderProposalRepository.AddProposal(proposal);
                _serviceNotificationRepository.AddAsync(new AddServiceNotificationVM
                {
                    RequestId = proposal.ServiceRequestId,
                    ServiceProviderId = proposal.ServiceProviderId,
                    ClientId = proposal.ServiceRequest.ClientId,
                    Message = $"New proposal created for request ID {proposal.ServiceRequestId}."
                });

                return ServiceResult<ServiceProviderProposalDetailsVM>.SuccessResult(proposal.ToDetailsViewModel(), "Proposal created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceProviderProposalDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<List<ServiceProviderProposalDetailsVM>> GetProposalsByRequest(int requestId)
        {
            try
            {
                if (requestId <= 0)
                    return ServiceResult<List<ServiceProviderProposalDetailsVM>>.FailureResult("Request ID must be greater than zero.");

                var proposals = _serviceProviderProposalRepository.GetProposalsByRequest(requestId);
                var data = proposals.Select(p => p.ToDetailsViewModel()).ToList();

                return ServiceResult<List<ServiceProviderProposalDetailsVM>>.SuccessResult(data, "Proposals retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<ServiceProviderProposalDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceProviderProposalDetailsVM>> GetProposalsByProvider(
            string providerId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(providerId))
                    return ServiceResult<PaginationViewModel<ServiceProviderProposalDetailsVM>>.FailureResult("Provider ID cannot be null or empty.");

                var totalCount = _serviceProviderProposalRepository.GetProposalsByProvider(providerId).Count();
                var proposals = _serviceProviderProposalRepository.GetProposalsByProvider(providerId);
                var data = proposals.Select(p => p.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceProviderProposalDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceProviderProposalDetailsVM>>.SuccessResult(paginationResult, "Proposals retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceProviderProposalDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<ServiceProviderProposalDetailsVM> GetProposalById(int proposalId)
        {
            try
            {
                var proposal = _serviceProviderProposalRepository.GetProposalWithDetails(proposalId);
                if (proposal == null)
                    return ServiceResult<ServiceProviderProposalDetailsVM>.FailureResult("Proposal not found.");

                return ServiceResult<ServiceProviderProposalDetailsVM>.SuccessResult(proposal.ToDetailsViewModel(), "Proposal retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceProviderProposalDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult UpdateProposal(int proposalId, [FromForm] AddServiceProviderProposalVM vm)
        {
            try
            {
                var proposal = _serviceProviderProposalRepository.GetProposalWithDetails(proposalId);
                if (proposal == null)
                    return ServiceResult.FailureResult("Proposal not found.");

                var updatedProposal = vm.ToModel();
                updatedProposal.Id = proposalId;
                updatedProposal.ServiceRequestId = proposal.ServiceRequestId;
                updatedProposal.ServiceProviderId = proposal.ServiceProviderId;
                _serviceProviderProposalRepository.Update(updatedProposal);
                return ServiceResult.SuccessResult("Proposal updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult AcceptProposal(int proposalId)
        {
            try
            {
                if (proposalId <= 0)
                    return ServiceResult.FailureResult("Proposal ID must be greater than zero.");

                var proposal = _serviceProviderProposalRepository.GetProposalWithDetails(proposalId);
                if (proposal == null)
                    return ServiceResult.FailureResult("Proposal not found.");

                // Check if the proposal is already accepted or rejected
                if (proposal.Status != ProposalStatus.Pending)
                    return ServiceResult.FailureResult("Proposal is already processed (accepted or rejected).");

                // Accept the selected proposal
                _serviceProviderProposalRepository.AcceptProposal(proposalId);
                var updated = _serviceRequestRepository.UpdaterequestsStatus(proposal.ServiceRequestId, RequestStatus.InProgress);
                if (!updated)
                    return ServiceResult<bool>.FailureResult("Request not found");

                _serviceNotificationRepository.AddAsync(new AddServiceNotificationVM
                {
                    RequestId = proposal.ServiceRequestId,
                    ServiceProviderId = proposal.ServiceProviderId,
                    ClientId = proposal.ServiceRequest.ClientId,
                    Message = $"New proposal created for request ID {proposal.ServiceRequestId}."
                });
                var otherProposals = _serviceProviderProposalRepository.GetProposalsByRequest(proposal.ServiceRequestId)
                    .Where(p => p.Id != proposalId && p.Status == ProposalStatus.Pending)
                    .ToList();

                foreach (var otherProposal in otherProposals)
                {
                    _serviceProviderProposalRepository.RejectProposal(otherProposal.Id);
                }

                return ServiceResult.SuccessResult("Proposal accepted successfully, and other proposals have been rejected.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult RejectProposal(int proposalId)
        {
            try
            {
                if (proposalId <= 0)
                    return ServiceResult.FailureResult("Proposal ID must be greater than zero.");

                var proposal = _serviceProviderProposalRepository.GetProposalWithDetails(proposalId);
                if (proposal == null)
                    return ServiceResult.FailureResult("Proposal not found.");

                if (proposal.Status != ProposalStatus.Pending)
                    return ServiceResult.FailureResult("Proposal is already processed (accepted or rejected).");

                _serviceProviderProposalRepository.RejectProposal(proposalId);
                _serviceNotificationRepository.AddAsync(new AddServiceNotificationVM
                {
                    RequestId = proposal.ServiceRequestId,
                    ServiceProviderId = proposal.ServiceProviderId,
                    ClientId = proposal.ServiceRequest.ClientId,
                    Message = $"New proposal created for request ID {proposal.ServiceRequestId}."
                });
                return ServiceResult.SuccessResult("Proposal rejected successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult CancelProposals(int serviceRequestId)
        {
            try
            {
                if (serviceRequestId <= 0)
                    return ServiceResult.FailureResult("Service Request ID must be greater than zero.");

                var request = _serviceRequestRepository.GetRequestWithDetails(serviceRequestId);
                if (request == null)
                    return ServiceResult.FailureResult("Service request not found.");

                var proposals = _serviceProviderProposalRepository.GetProposalsByRequest(serviceRequestId)
                    .Where(p => p.Status == ProposalStatus.Pending)
                    .ToList();

                if (!proposals.Any())
                    return ServiceResult.FailureResult("No pending proposals found for this service request.");
                foreach(var proposal in proposals)
                {
                    _serviceNotificationRepository.AddAsync(new AddServiceNotificationVM
                    {
                        RequestId = proposal.ServiceRequestId,
                        ServiceProviderId = proposal.ServiceProviderId,
                        ClientId = proposal.ServiceRequest.ClientId,
                        Message = $"New proposal created for request ID {proposal.ServiceRequestId}."
                    });
                }


                foreach (var proposal in proposals)
                {
                    _serviceProviderProposalRepository.RejectProposal(proposal.Id);
                }

                return ServiceResult.SuccessResult("All pending proposals for the service request have been canceled (rejected).");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult DeleteProposal(int proposalId)
        {
            try
            {
                if (proposalId <= 0)
                    return ServiceResult.FailureResult("Proposal ID must be greater than zero.");

                var proposal = _serviceProviderProposalRepository.GetById(proposalId);
                if (proposal == null)
                    return ServiceResult.FailureResult("Proposal not found.");

                _serviceProviderProposalRepository.Delete(proposal);
                _serviceNotificationRepository.AddAsync(new AddServiceNotificationVM
                {
                    RequestId = proposal.ServiceRequestId,
                    ServiceProviderId = proposal.ServiceProviderId,
                    ClientId = proposal.ServiceRequest.ClientId,
                    Message = $"New proposal created for request ID {proposal.ServiceRequestId}."
                });
                return ServiceResult.SuccessResult("Proposal deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult CompleteProposal(int proposalId)
        {
            try
            {
                if (proposalId <= 0)
                    return ServiceResult.FailureResult("Proposal ID must be greater than zero.");
                var proposal = _serviceProviderProposalRepository.GetProposalWithDetails(proposalId);
                if (proposal == null)
                    return ServiceResult.FailureResult("Proposal not found.");
                if (proposal.Status != ProposalStatus.Accepted)
                    return ServiceResult.FailureResult("Proposal must be accepted before it can be completed.");
                _serviceProviderProposalRepository.CompleteProposal(proposalId);
                _serviceNotificationRepository.AddAsync(new AddServiceNotificationVM
                {
                    RequestId = proposal.ServiceRequestId,
                    ServiceProviderId = proposal.ServiceProviderId,
                    ClientId = proposal.ServiceRequest.ClientId,
                    Message = $"New proposal created for request ID {proposal.ServiceRequestId}."
                });
                _serviceRequestRepository.UpdaterequestsStatus(proposal.ServiceRequestId, RequestStatus.Completed);
                return ServiceResult.SuccessResult("Proposal completed successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        #endregion

        #region ServiceProviderProject

        public ServiceResult<ServiceProviderProjectDetailsVM> CreateProject([FromForm] AddServiceProviderProjectVM vm, List<IFormFile> imageFiles)
        {
            try
            {
                var project = vm.ToModel();

                if (string.IsNullOrEmpty(project.Name))
                    return ServiceResult<ServiceProviderProjectDetailsVM>.FailureResult("Project name cannot be null or empty.");

                List<string> imagePaths = new List<string>();
                if (imageFiles != null && imageFiles.Any())
                {
                    foreach (var file in imageFiles)
                    {
                        var imagePath = SaveImageFile(file, project.ServiceProviderId);
                        imagePaths.Add(imagePath);
                    }
                }

                _serviceProviderProjectRepository.AddProject(project, imagePaths);
                return ServiceResult<ServiceProviderProjectDetailsVM>.SuccessResult(project.ToDetailsViewModel(), "Project created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceProviderProjectDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceProviderProjectDetailsVM>> GetProjectsByProvider(string providerId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(providerId))
                    return ServiceResult<PaginationViewModel<ServiceProviderProjectDetailsVM>>.FailureResult("Provider ID cannot be null or empty.");

                var query = _serviceProviderProjectRepository.GetProjects(providerId);

                var totalCount = query.Count();
                var data = query.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .Select(p => p.ToDetailsViewModel())
                                .ToList();

                return ServiceResult<PaginationViewModel<ServiceProviderProjectDetailsVM>>.SuccessResult(new PaginationViewModel<ServiceProviderProjectDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                }, "Projects retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceProviderProjectDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<ServiceProviderProjectDetailsVM> GetProjectById(int projectId)
        {
            try
            {
                var project = _serviceProviderProjectRepository.GetById(projectId);
                if (project == null)
                    return ServiceResult<ServiceProviderProjectDetailsVM>.FailureResult("Project not found.");

                return ServiceResult<ServiceProviderProjectDetailsVM>.SuccessResult(project.ToDetailsViewModel(), "Project retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceProviderProjectDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult UpdateProject(int projectId, [FromForm] AddServiceProviderProjectVM vm, List<IFormFile> imageFiles = null)
        {
            try
            {
                var existingProject = _serviceProviderProjectRepository.GetById(projectId);
                if (existingProject == null)
                    return ServiceResult.FailureResult("Project not found.");

                var updatedProject = vm.ToModel();
                updatedProject.Id = projectId;
                updatedProject.ServiceProviderId = existingProject.ServiceProviderId;

                List<string> imagePaths = new List<string>();
                if (imageFiles != null && imageFiles.Any())
                {
                    foreach (var file in imageFiles)
                    {
                        var imagePath = SaveImageFile(file, existingProject.ServiceProviderId);
                        imagePaths.Add(imagePath);
                    }
                }

                _serviceProviderProjectRepository.UpdateProject(updatedProject, imagePaths);
                return ServiceResult.SuccessResult("Project updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult UpdateProjectImage(int projectId, List<IFormFile> imageFiles)
        {
            try
            {
                if (projectId <= 0)
                    return ServiceResult.FailureResult("Invalid project ID.");

                if (imageFiles == null || !imageFiles.Any())
                    return ServiceResult.FailureResult("No image files provided.");

                var project = _serviceProviderProjectRepository.GetById(projectId);
                if (project == null)
                    return ServiceResult.FailureResult("Project not found.");

                var imagePaths = imageFiles.Select(file => SaveImageFile(file, project.ServiceProviderId)).ToList();
                _serviceProviderProjectRepository.UpdateProjectImage(projectId, imagePaths);

                return ServiceResult.SuccessResult("Project images updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult DeleteProject(int projectId)
        {
            try
            {
                if (projectId <= 0)
                    return ServiceResult.FailureResult("Invalid project ID.");

                _serviceProviderProjectRepository.DeleteProject(projectId);
                return ServiceResult.SuccessResult("Project deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        private string SaveImageFile(IFormFile file, string serviceProviderId)
        {
            string folder = Path.Combine("uploads", "projects", serviceProviderId);
            string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder);

            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(root, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine(folder, fileName).Replace("\\", "/");
        }

        #endregion


        #region CategoryServices

        public ServiceResult<CategoryServicesDetailsVM> CreateCategory([FromForm] AddCategoryServicesVM vm)
        {
            try
            {
                if (string.IsNullOrEmpty(vm.Name))
                    return ServiceResult<CategoryServicesDetailsVM>.FailureResult("Category name cannot be null or empty.");
                if (string.IsNullOrEmpty(vm.Description))
                    return ServiceResult<CategoryServicesDetailsVM>.FailureResult("Description cannot be null or empty.");

                var category = vm.ToModel();
                _categoryServicesRepository.Add(category);
                return ServiceResult<CategoryServicesDetailsVM>.SuccessResult(category.ToDetailsViewModel(), "Category created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<CategoryServicesDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<CategoryServicesDetailsVM>> SearchCategories(
               string searchTerm = "", int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                var totalCount = _categoryServicesRepository.GetCategories(searchTerm).Count();
                var categories = _categoryServicesRepository.GetCategories(searchTerm, pageSize, pageNumber);
                var data = categories.Select(c => c.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<CategoryServicesDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<CategoryServicesDetailsVM>>.SuccessResult(paginationResult, "Categories retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<CategoryServicesDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<CategoryServicesDetailsVM> GetCategoryById(int categoryId)
        {
            try
            {
                var category = _categoryServicesRepository.GetCategoryById(categoryId);
                if (category == null)
                    return ServiceResult<CategoryServicesDetailsVM>.FailureResult("Category not found.");

                return ServiceResult<CategoryServicesDetailsVM>.SuccessResult(category.ToDetailsViewModel(), "Category retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<CategoryServicesDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }



        public ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>> GetServiceProvidersForCategory(
            int categoryId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (categoryId <= 0)
                    return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.FailureResult("Category ID must be greater than zero.");

                var totalCount = _categoryServicesRepository.GetPaginatedServiceProviders(categoryId).Count();
                var providers = _categoryServicesRepository.GetPaginatedServiceProviders(categoryId, pageSize, pageNumber);
                var data = providers.Select(p => p.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceProviderDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.SuccessResult(paginationResult, "Service providers retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>> GetQueriesForCategory(
    int categoryId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (categoryId <= 0 || pageSize <= 0 || pageNumber <= 0)
                    return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.FailureResult("Invalid input parameters.");

                var baseQuery = _serviceQuariesRepository.GetQueriesByCategory(categoryId);
                var totalCount = baseQuery.Count();

                var data = baseQuery
                         .Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                         .Select(q => q.ToDetailsViewModel())
                         .ToList();

                var result = new PaginationViewModel<ServiceQuariesDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.SuccessResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceQuariesDetailsVM>>.FailureResult(ex.Message);
            }
        }

        public ServiceResult UpdateCategory(int categoryId, [FromForm] AddCategoryServicesVM vm)
        {
            try
            {
                var category = _categoryServicesRepository.GetCategoryById(categoryId);
                if (category == null)
                    return ServiceResult.FailureResult("Category not found.");

                category.Name = vm.Name;
                category.Description = vm.Description;

                _categoryServicesRepository.Update(category);
                _categoryServicesRepository.Save(); 

                return ServiceResult.SuccessResult("Category updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }



        public ServiceResult UpdateCategoryImage(int categoryId, [FromForm] string newImagePath)
        {
            try
            {
                if (categoryId <= 0)
                    return ServiceResult.FailureResult("Category ID must be greater than zero.");
                if (string.IsNullOrEmpty(newImagePath))
                    return ServiceResult.FailureResult("Image path cannot be null or empty.");

                var success = _categoryServicesRepository.UpdateCategoryImage(categoryId, newImagePath);
                if (!success)
                    return ServiceResult.FailureResult("Category not found.");

                return ServiceResult.SuccessResult("Category image updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult DeleteCategory(int categoryId)
        {
            try
            {
                if (categoryId <= 0)
                    return ServiceResult.FailureResult("Category ID must be greater than zero.");

                var category = _categoryServicesRepository.GetCategoryById(categoryId);
                if (category == null)
                    return ServiceResult.FailureResult("Category not found.");

                _categoryServicesRepository.Delete(category);
                _categoryServicesRepository.Save();

                return ServiceResult.SuccessResult("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }



        public ServiceResult<PaginationViewModel<CategoryServicesDetailsVM>> GetPopularCategories(int count)
        {
            try
            {
                if (count <= 0)
                    return ServiceResult<PaginationViewModel<CategoryServicesDetailsVM>>.FailureResult("Count must be greater than zero.");

                var baseQuery = _categoryServicesRepository.GetPopularCategories(count);

                var totalCount = baseQuery.Count();

                var data = baseQuery
                         .AsQueryable() 
                         .Select(c => c.ToDetailsViewModel())
                         .ToList();

                var paginationResult = new PaginationViewModel<CategoryServicesDetailsVM>
                {
                    Data = data,
                    PageNumber = 1,
                    PageSize = totalCount, 
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<CategoryServicesDetailsVM>>.SuccessResult(paginationResult, "Popular categories retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<CategoryServicesDetailsVM>>.FailureResult($"Error retrieving categories: {ex.Message}");
            }
        }

        public ServiceResult<List<CategoryServicesDetailsVM>> GetAllCategories()
        {
            try
            {
                var categories = _categoryServicesRepository.Get()
                    .Select(c => c.ToDetailsViewModel())
                    .ToList();

                return ServiceResult<List<CategoryServicesDetailsVM>>.SuccessResult(categories, "Categories retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<CategoryServicesDetailsVM>>.FailureResult($"Error retrieving categories: {ex.Message}");
            }
        }


        #endregion

        #region ServiceProviderReview

        public ServiceResult<ServiceProviderReviewDetailsVM> CreateReview([FromForm] AddServiceProviderReviewVM vm)
        {
            try
            {
                var review = vm.ToModel();
                if (review.Rating < 1 || review.Rating > 5)
                    return ServiceResult<ServiceProviderReviewDetailsVM>.FailureResult("Rating must be between 1 and 5.");
                if (string.IsNullOrEmpty(review.Review))
                    return ServiceResult<ServiceProviderReviewDetailsVM>.FailureResult("Review text cannot be null or empty.");

                _serviceProviderReviewRepository.AddReview(review);
                return ServiceResult<ServiceProviderReviewDetailsVM>.SuccessResult(review.ToDetailsModel(), "Review created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceProviderReviewDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }


        public ServiceResult<ServiceProviderReviewDetailsVM> GetReviewByRequest(int requestId)
        {
            try
            {
                if (requestId <= 0)
                    return ServiceResult<ServiceProviderReviewDetailsVM>.FailureResult("Request ID must be greater than zero.");

                var review = _serviceProviderReviewRepository.GetReviewByRequest(requestId);
                if (review == null)
                    return ServiceResult<ServiceProviderReviewDetailsVM>.FailureResult("Review not found.");

                return ServiceResult<ServiceProviderReviewDetailsVM>.SuccessResult(review.ToDetailsModel(), "Review retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceProviderReviewDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }




        public ServiceResult<PaginationViewModel<ServiceProviderReviewDetailsVM>> GetReviewsByProvider(
            string providerId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(providerId))
                    return ServiceResult<PaginationViewModel<ServiceProviderReviewDetailsVM>>.FailureResult("Provider ID cannot be null or empty.");

                var totalCount = _serviceProviderReviewRepository.GetReviewsByProvider(providerId).Count();
                var reviews = _serviceProviderReviewRepository.GetReviewsByProvider(providerId, pageSize, pageNumber);
                var data = reviews.Select(r => r.ToDetailsModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceProviderReviewDetailsVM>
                {
                    Data = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceProviderReviewDetailsVM>>.SuccessResult(paginationResult, "Reviews retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceProviderReviewDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult UpdateReview(int reviewId, [FromForm] AddServiceProviderReviewVM vm)
        {
            try
            {
                var review = _serviceProviderReviewRepository.GetById(reviewId);
                if (review == null)
                    return ServiceResult.FailureResult("Review not found.");

                var updatedReview = vm.ToModel();
                updatedReview.Id = reviewId;
                updatedReview.ServiceRequest.Id = review.Id;
                _serviceProviderReviewRepository.Update(updatedReview);
                return ServiceResult.SuccessResult("Review updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult DeleteReview(int reviewId)
        {
            try
            {
                if (reviewId <= 0)
                    return ServiceResult.FailureResult("Review ID must be greater than zero.");

                var success = _serviceProviderReviewRepository.GetById(reviewId);
                if (success == null)
                    return ServiceResult.FailureResult("Review not found.");

                _serviceProviderReviewRepository.Delete(success);
                return ServiceResult.SuccessResult("Review deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        #endregion

        #region ServiceProviderPayment
                    

        public ServiceResult<ServiceProviderPaymentDetailsVM> CreatePayment([FromForm] AddServiceProviderPayment vm)
{
    try
    {
        var payment = vm.ToModel();
        if (payment.Amount <= 0)
            return ServiceResult<ServiceProviderPaymentDetailsVM>.FailureResult("Amount must be greater than zero.");

        _serviceProviderPaymentRepository.Add(payment);
        return ServiceResult<ServiceProviderPaymentDetailsVM>.SuccessResult(payment.ToDetailsViewModel(), "Payment created successfully.");
    }
    catch (Exception ex)
    {
        return ServiceResult<ServiceProviderPaymentDetailsVM>.FailureResult("Error: " + ex.Message);
    }
}

public ServiceResult<ServiceProviderPaymentDetailsVM> GetPaymentByRequest(int requestId)
{
    try
    {
        if (requestId <= 0)
            return ServiceResult<ServiceProviderPaymentDetailsVM>.FailureResult("Request ID must be greater than zero.");

        var payment = _serviceProviderPaymentRepository.GetPaymentByRequest(requestId);
        if (payment == null)
            return ServiceResult<ServiceProviderPaymentDetailsVM>.FailureResult("Payment not found.");

        return ServiceResult<ServiceProviderPaymentDetailsVM>.SuccessResult(payment.ToDetailsViewModel(), "Payment retrieved.");
    }
    catch (Exception ex)
    {
        return ServiceResult<ServiceProviderPaymentDetailsVM>.FailureResult("Error: " + ex.Message);
    }
}

public ServiceResult<PaginationViewModel<ServiceProviderPaymentDetailsVM>> GetPaymentsByProvider(
    string providerId, int pageSize = 5, int pageNumber = 1)
{
    try
    {
        if (string.IsNullOrEmpty(providerId))
            return ServiceResult<PaginationViewModel<ServiceProviderPaymentDetailsVM>>.FailureResult("Provider ID cannot be null or empty.");

        var totalCount = _serviceProviderPaymentRepository.GetPaymentsByProvider(providerId).Count();
        var payments = _serviceProviderPaymentRepository.GetPaymentsByProvider(providerId, pageSize, pageNumber);
        var data = payments.Select(p => p.ToDetailsViewModel()).ToList();

        var paginationResult = new PaginationViewModel<ServiceProviderPaymentDetailsVM>
        {
            Data = data,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };

        return ServiceResult<PaginationViewModel<ServiceProviderPaymentDetailsVM>>.SuccessResult(paginationResult, "Payments retrieved.");
    }
    catch (Exception ex)
    {
        return ServiceResult<PaginationViewModel<ServiceProviderPaymentDetailsVM>>.FailureResult("Error: " + ex.Message);
    }
}

public ServiceResult UpdatePayment(int paymentId, [FromForm] AddServiceProviderPayment vm)
{
    try
    {
        var payment = _serviceProviderPaymentRepository.GetById(paymentId);
        if (payment == null)
            return ServiceResult.FailureResult("Payment not found.");

        var updatedPayment = vm.ToModel();
        updatedPayment.Id = paymentId;
        updatedPayment.ServiceRequest.Id = payment.ServiceRequest.Id;
        _serviceProviderPaymentRepository.Update(updatedPayment);
        return ServiceResult.SuccessResult("Payment updated successfully.");
    }
    catch (Exception ex)
    {
        return ServiceResult.FailureResult("Error: " + ex.Message);
    }
}

public ServiceResult UpdatePaymentStatus(int paymentId, PaymentStatus status)
{
    try
    {
        if (paymentId <= 0)
            return ServiceResult.FailureResult("Payment ID must be greater than zero.");

        var success = _serviceProviderPaymentRepository.UpdatePaymentStatus(paymentId, status);
        if (!success)
            return ServiceResult.FailureResult("Payment not found.");

        return ServiceResult.SuccessResult("Payment status updated successfully.");
    }
    catch (Exception ex)
    {
        return ServiceResult.FailureResult("Error: " + ex.Message);
    }
}

public ServiceResult DeletePayment(int paymentId)
{
    try
    {
        if (paymentId <= 0)
            return ServiceResult.FailureResult("Payment ID must be greater than zero.");

        var success = _serviceProviderPaymentRepository.GetById(paymentId);
        if (success == null)
            return ServiceResult.FailureResult("Payment not found.");
                _serviceProviderPaymentRepository.Delete(success);
        return ServiceResult.SuccessResult("Payment deleted successfully.");
    }
    catch (Exception ex)
    {
        return ServiceResult.FailureResult("Error: " + ex.Message);
    }
}


        #endregion

        #region ServiceProvider

        public ServiceResult<ServiceProviderDetailsVM> CreateServiceProvider([FromForm] AddServiceProviderVM vm)
        {
            try
            {

                if (_categoryServicesRepository.GetById(vm.CategoryServicesId) == null)
                    return ServiceResult<ServiceProviderDetailsVM>.FailureResult($"Category with ID {vm.CategoryServicesId} does not exist.");
                vm.Imagepath = uploader.addimage(vm.Image);

                var current =  _serviceProviderRepository.GetProviderWithDetails(providerId: vm.UserId);
                var provider = vm.ToEditModel(current);

                // Save profile image if provided

                _serviceProviderRepository.Update(provider);
                _serviceProviderRepository.Save();

                return ServiceResult<ServiceProviderDetailsVM>.SuccessResult(provider.ToDetailsViewModel(), "Service provider created successfully.");
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                if (ex.InnerException != null)
                    errorMessage += $"\nInner Exception: {ex.InnerException.Message}";
                return ServiceResult<ServiceProviderDetailsVM>.FailureResult($"Error: {errorMessage}");
            }
        }

        public ServiceResult<bool> CheckProfileCompleteness(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                    return ServiceResult<bool>.FailureResult("User ID cannot be null or empty.");

                var isComplete = _serviceProviderRepository.CheckProfileCompleteness(userId);
                return ServiceResult<bool>.SuccessResult(isComplete, isComplete ? "Profile is complete." : "Profile is incomplete.");
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>> SearchServiceProviders(
            string? searchText = "",
            int? categoryId = null,
            string? address = null,
            string sortBy = "Name",
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            try
            {
                var providers = _serviceProviderRepository.GetList();

                if (!string.IsNullOrEmpty(searchText))
                    providers = providers.Where(p => p.AppUser.UserName.Contains(searchText, StringComparison.OrdinalIgnoreCase));

                if (categoryId.HasValue)
                    providers = providers.Where(p => p.CategoryServicesId == categoryId.Value);

                if (!string.IsNullOrEmpty(address))
                    providers = providers.Where(p => p.Address != null && p.Address.Contains(address, StringComparison.OrdinalIgnoreCase));

                switch (sortBy.ToLower())
                {
                    case "name":
                        providers = descending ? providers.OrderByDescending(p => p.AppUser.UserName) : providers.OrderBy(p => p.AppUser.UserName);
                        break;
                    case "averagerating":
                        providers = descending ? providers.OrderByDescending(p => p.AverageRating) : providers.OrderBy(p => p.AverageRating);
                        break;
                    default:
                        providers = providers.OrderBy(p => p.UserId);
                        break;
                }

                var totalCount = providers.Count();
                var paginatedProviders = providers
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var data = paginatedProviders.Select(p => p.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceProviderDetailsVM>
                {
                    Data = data,
                    PageNumber = pageIndex,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.SuccessResult(paginationResult, "Service providers retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<ServiceProviderDetailsVM> GetServiceProviderById(string providerId)
        {
            try
            {
                if (string.IsNullOrEmpty(providerId))
                    return ServiceResult<ServiceProviderDetailsVM>.FailureResult("Provider ID cannot be null or empty.");

                var provider = _serviceProviderRepository.GetProviderWithDetails(providerId);
                if (provider == null)
                    return ServiceResult<ServiceProviderDetailsVM>.FailureResult("Service provider not found.");

                return ServiceResult<ServiceProviderDetailsVM>.SuccessResult(provider.ToDetailsViewModel(), "Service provider retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceProviderDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>> GetProvidersByCategory(int categoryId, int pageSize = 5, int pageNumber = 1)
        {
            try
            {
                if (categoryId <= 0)
                    return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.FailureResult("Category ID must be greater than zero.");

                var providers = _serviceProviderRepository.GetProvidersByCategory(categoryId).AsQueryable();
                var totalCount = providers.Count();

                var paginatedData = providers
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(p => p.ToDetailsViewModel())
                    .ToList();

                var paginationResult = new PaginationViewModel<ServiceProviderDetailsVM>
                {
                    Data = paginatedData,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.SuccessResult(paginationResult, "Service providers retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.FailureResult($"An error occurred: {ex.Message}");
            }
        }

        public ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>> GetTopRatedProviders(int count)
        {
            try
            {
                if (count <= 0)
                    return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.FailureResult("Count must be greater than zero.");

                var providers = _serviceProviderRepository.GetTopRatedProviders(count);
                var totalCount = providers.Count();
                var data = providers.Select(p => p.ToDetailsViewModel()).ToList();

                var paginationResult = new PaginationViewModel<ServiceProviderDetailsVM>
                {
                    Data = data,
                    PageNumber = 1,
                    PageSize = totalCount,
                    TotalCount = totalCount
                };

                return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.SuccessResult(paginationResult, "Top-rated providers retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<ServiceProviderDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<bool> ProviderExists(string providerId)
        {
            try
            {
                if (string.IsNullOrEmpty(providerId))
                    return ServiceResult<bool>.FailureResult("Provider ID cannot be null or empty.");

                var exists = _serviceProviderRepository.ProviderExists(providerId);
                return ServiceResult<bool>.SuccessResult(exists, exists ? "Provider exists." : "Provider does not exist.");
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<ServiceProviderDetailsVM> UpdateServiceProvider(int providerId, [FromForm] AddServiceProviderVM vm)
        {
            try
            {
                if (string.IsNullOrEmpty(vm.UserId))
                    return ServiceResult<ServiceProviderDetailsVM>.FailureResult("Name cannot be null or empty.");

                var provider = _serviceProviderRepository.GetById(providerId);
                if (provider == null)
                    return ServiceResult<ServiceProviderDetailsVM>.FailureResult("Service provider not found.");

                //provider.AppUser.UserName = vm.UserName;
                provider.Address = vm.Address;
                provider.CategoryServicesId = vm.CategoryServicesId;
                provider.City = vm.City;
                provider.Country = vm.Country;

                // Save new image if provided
                var newImagePath = SaveProfileImage(vm.Image);
                if (!string.IsNullOrEmpty(newImagePath))
                {
                    provider.Image = newImagePath;
                }

                _serviceProviderRepository.Update(provider);

                return ServiceResult<ServiceProviderDetailsVM>.SuccessResult(provider.ToDetailsViewModel(), "Service provider updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceProviderDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult DeleteServiceProvider(int providerId)
        {
            try
            {
                var success = _serviceProviderRepository.GetById(providerId);
                if (success == null)
                    return ServiceResult.FailureResult("Service provider not found.");

                _serviceProviderRepository.Delete(success);
                return ServiceResult.SuccessResult("Service provider deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        // Helper method to save image
        private string? SaveProfileImage(IFormFile? imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "providers");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return Path.Combine("uploads", "providers", uniqueFileName).Replace("\\", "/");
        }

        #endregion

    }
}
