using GroceryApp.Model;
using GroceryApp.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_categoryService.GetCategories(0, 10));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var data = _categoryService.GetCategoryById(id);

        if (data == null)
            return NotFound("Not Found");

        return Ok(data);
    }

    [HttpPost]
    public IActionResult Create(CategoryModel category)
    {
        _categoryService.AddCategory(category);
        return Ok("Category Added");
    }

    [HttpPut]
    public IActionResult Update(CategoryModel category)
    {
        _categoryService.UpdateCategory(category);
        return Ok("Updated Successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _categoryService.DeleteCategory(id);
        return Ok("Deleted Successfully");
    }
}