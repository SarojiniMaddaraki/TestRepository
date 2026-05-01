using GroceryApp.Model;
using GroceryApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ItemController : ControllerBase
{
    private readonly ItemService _itemService;

    public ItemController(ItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_itemService.GetItems(0, 10));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var item = _itemService.GetItemById(id);

        if (item == null)
            return NotFound("Item Not Found");

        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(ItemModel item)
    {
        _itemService.AddItem(item);
        return Ok("Item Added");
    }

    [HttpPut]
    public IActionResult Update(ItemModel item)
    {
        _itemService.UpdateItem(item);
        return Ok("Updated Successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var data = _itemService.GetItemById(id);

        if (data == null)
            return NotFound("Item Not Found");

        _itemService.DeleteItem(id);

        return Ok("Deleted Successfully");
    }
}