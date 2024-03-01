using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Model;
using MiniProject.Services;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await service.GetCategories();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await service.GetCategoryById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> Post([FromBody][Bind(include: "Cname")] Category category)
        {
            try
            {
                var result = await service.AddCategory(category);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> Put([FromBody] Category category)
        {
            try
            {
                var result = await service.UpdateCategory(category);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteCategory(id);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
