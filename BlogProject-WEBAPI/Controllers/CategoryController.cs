using BlogProject.Core.DomainModels.Models;
using BlogProject_Application_2.DTOs;
using BlogProject_Application_2.Utilities.IUnitOfWork;
using BlogProject_Application_2.Utilities.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly ILogging _logger;

        public CategoryController(IUnitOfWorkService unitOfWorkService, ILogging logger)
        {
            _unitOfWorkService = unitOfWorkService;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<CategoryDTO>> GetDeneme()
        {
            var categories = await _unitOfWorkService.CategoryService.GetAllCategoryiesAsync();
            return categories;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateCategory(CategoryDTO categoryDTO)
        {
            var result = _unitOfWorkService.CategoryService.CreateCategory(categoryDTO);
            if (result >0) return Ok(result);
            return BadRequest();
        }
    }
}
