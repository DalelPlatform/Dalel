using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeServices;
using Dalel.ViewModels.HomeServices.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryServicesController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public CategoryServicesController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }

        [HttpPost("create")]
        //[Authorize(Roles = "Admin")]
        public IActionResult CreateCategory([FromForm] AddCategoryServicesVM model)
        {
            var result = _homeServiceService.CreateCategory(model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("search")]
        public IActionResult SearchCategories(
            [FromQuery] string searchTerm = "",
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.SearchCategories(searchTerm, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var result = _homeServiceService.GetCategoryById(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("providers/{categoryId}")]
        public IActionResult GetServiceProvidersForCategory(
            int categoryId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            // Specify the exact method to resolve ambiguity
            var result = _homeServiceService.GetServiceProvidersForCategory(categoryId: categoryId, pageSize: pageSize, pageNumber: pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("queries/{categoryId}")]
        public IActionResult GetQueriesForCategory(
            int categoryId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetQueriesForCategory(categoryId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult UpdateCategory(int id, [FromForm] AddCategoryServicesVM model)
        {
            var result = _homeServiceService.UpdateCategory(id, model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("image/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult UpdateCategoryImage(int id, [FromForm] string newImagePath)
        {
            var result = _homeServiceService.UpdateCategoryImage(id, newImagePath);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _homeServiceService.DeleteCategory(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("popular/{count}")]
        public IActionResult GetPopularCategories(int count)
        {
            var result = _homeServiceService.GetPopularCategories(count);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            var result = _homeServiceService.GetAllCategories();
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
    }
}