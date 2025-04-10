using Dalel.Repository.HomeServices;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeServices;
using Dalel.ViewModels.HomeServices.CategoryServices;
using Dalel.ViewModels.HomeServices.ServiceQuaries;
using Grpc.Core;
using Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Dalel.Services.ServiceProvicerService
{
    public class Services
    {
        private readonly HomeServiceRepository _repository;

        public Services(HomeServiceRepository repository)
        {
            _repository = repository;
        }

        // CategoryServices
        public ServiceResult<IQueryable<CategoryServicesDetailsVM>> GetCategories()
        {
            try
            {
                var categories = _repository.GetCategories().Select(c => c.ToDetailsModel());
                return ServiceResult<IQueryable<CategoryServicesDetailsVM>>.SuccessResult(categories, "Categories retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IQueryable<CategoryServicesDetailsVM>>.FailureResult($"Failed to retrieve categories: {ex.Message}");
            }
        }

        public ServiceResult<CategoryServicesDetailsVM> GetCategoryById(int id)
        {
            try
            {
                var category = _repository.GetCategoryById(id);
                if (category == null)
                {
                    return ServiceResult<CategoryServicesDetailsVM>.FailureResult("Category not found.");

                }
                return ServiceResult<CategoryServicesDetailsVM>.SuccessResult(category.ToDetailsModel(), "Category retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<CategoryServicesDetailsVM>.FailureResult($"Failed to retrieve category: {ex.Message}");
            }
        }

        public ServiceResult AddCategory(AddCategoryServicesVM vm)
        {
            try
            {
                if (vm == null || string.IsNullOrEmpty(vm.Name))
                {
                    return ServiceResult.FailureResult("Invalid category data.");
                    ;
                }
                var category = vm.ToModel();
                _repository.AddCategory(category);
                return ServiceResult.SuccessResult("Category added successfully.");
                ;
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Failed to add category: {ex.Message}");
                ;
            }
        }

        public ServiceResult UpdateCategory(CategoryServicesDetailsVM vm)
        {
            try
            {
                var category = _repository.GetCategoryById(vm.Id);
                if (category == null)
                {
                    return ServiceResult.FailureResult("Category not found.");
                    ;
                }
                category.Name = vm.Name;
                category.Image = vm.ImageUrl;
                category.Description = vm.Description;
                _repository.UpdateCategory(category);
                return ServiceResult.SuccessResult("Category updated successfully.");

            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Failed to update category: {ex.Message}");

            }
        }

        public ServiceResult DeleteCategory(int id)
        {
            try
            {
                var category = _repository.GetCategoryById(id);
                if (category == null)
                {
                    return ServiceResult.FailureResult("Category not found.")
                    ;
                }
                _repository.DeleteCategory(id);
                return ServiceResult.SuccessResult("Category deleted successfully.")
                ;
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Failed to delete category: {ex.Message}")
                ;
            }
        }

        // ServiceProviderProjects
        public ServiceResult<IQueryable<ServiceProviderProjectDetailsVM>> GetProjects(string serviceProviderId)
        {
            try
            {
                var projects = _repository.GetProjects(serviceProviderId).Select(p => p.ToDetailsModel());
                return ServiceResult<IQueryable<ServiceProviderProjectDetailsVM>>.SuccessResult(projects, "Projects retrieved successfully.");

            }
            catch (Exception ex)
            {
                return ServiceResult<IQueryable<ServiceProviderProjectDetailsVM>>.FailureResult($"Failed to retrieve projects: {ex.Message}");

            }
        }

        public ServiceResult<ServiceProviderProjectDetailsVM> GetProjectById(int id)
        {
            try
            {
                var project = _repository.GetProjectById(id);
                if (project == null)
                {
                    return ServiceResult<ServiceProviderProjectDetailsVM>.FailureResult("Project not found."); ;
                }
                return ServiceResult<ServiceProviderProjectDetailsVM>.SuccessResult(project.ToDetailsModel(), "Project retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ServiceProviderProjectDetailsVM>.FailureResult($"Failed to retrieve project: {ex.Message}");

            }
        }

        // Fix for CS1501: No overload for method 'ToModel' takes 1 arguments
        // The error indicates that the `ToModel` method is being called with one argument, but no such overload exists.
        // Based on the context, it seems `ToModel` might require additional parameters. Update the method call accordingly.

        public ServiceResult AddProject(AddServiceProviderProjectVM vm, string serviceProviderId)
        {
            try
            {
                if (vm == null || string.IsNullOrEmpty(vm.Name))
                {
                    return ServiceResult.FailureResult("Invalid project data.");
                }
                var project = vm.ToModel(serviceProviderId);

                _repository.AddProject(project);
                return ServiceResult.SuccessResult("Project added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Failed to add project: {ex.Message}");
            }
        }

        public ServiceResult UpdateProject(ServiceProviderProjectDetailsVM vm)
        {
            try
            {
                var project = _repository.GetProjectById(vm.Id);
                if (project == null)
                {
                    return ServiceResult.FailureResult("Project not found.");
                }
                project.Name = vm.Name;
                project.Description = vm.Description;
                project.ProjectImages = vm.ProjectImages;
                _repository.UpdateProject(project);
                return ServiceResult.SuccessResult("Project updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Failed to update project: {ex.Message}");
            }
        }

        public ServiceResult DeleteProject(int id)
        {
            try
            {
                var project = _repository.GetProjectById(id);
                if (project == null)
                {
                    return ServiceResult.FailureResult("Project not found.");
                }
                _repository.DeleteProject(id);
                return ServiceResult.SuccessResult("Project deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Failed to delete project: {ex.Message}");
            }
        }

        // ServiceProviderPropsal
        public ServiceResult AddProposal(AddServiceProviderProposalVM vm, string serviceProviderId)
        {
            try
            {
                if (vm == null || vm.SuggestedPrice <= 0)
                {
                    return ServiceResult.FailureResult("Invalid proposal data.");
                }
                var proposal = vm.ToModel();
                _repository.AddProposal(proposal);
                return ServiceResult.SuccessResult("Proposal added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Failed to add proposal: {ex.Message}");
            }
        }

        // ServiceQuaries
        public ServiceResult<IQueryable<ServiceQuariesDetailsVM>> GetQueries(string serviceProviderId)
        {
            try
            {
                var queries = _repository.GetQueries(serviceProviderId).Select(q => q.ToDetailsModel());
                return ServiceResult<IQueryable<ServiceQuariesDetailsVM>>.SuccessResult(queries, "Queries retrieved successfully.");

            }
            catch (Exception ex)
            {
                return ServiceResult<IQueryable<ServiceQuariesDetailsVM>>.FailureResult($"Failed to retrieve queries: {ex.Message}");
            }
        }

        public ServiceResult AnswerQuery(AddAnswerQueryVM vm)
        {
            try
            {
                var query = _repository.GetQueryById(vm.Id);
                if (query == null)
                {
                    return ServiceResult.FailureResult("Query not found.");
                }
                var updatedQuery = vm.ToModel(query);
                _repository.UpdateQuery(updatedQuery);
                return ServiceResult.SuccessResult("Query answered successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Failed to answer query: {ex.Message}");
            }
        }
    }
}
