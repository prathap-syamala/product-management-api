using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs.SubCategory;
using ProductApi.Services.Interfaces;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {

        private readonly ISubCategoryService _service;

        public SubCategoriesController(ISubCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
            => Ok(await _service.GetByCategoryIdAsync(categoryId));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.CreateAsync(dto);
                return Ok(new { message = "Sub-category added successfully" });
            }
            catch (InvalidOperationException ex)
            {
                // 🔴 Duplicate subcategory in same category
                return BadRequest(new { error = ex.Message });
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateSubCategoryDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
