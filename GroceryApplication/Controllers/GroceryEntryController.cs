using GroceryApp.Model;
using GroceryApp.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GroceryEntryController : ControllerBase
{
    private readonly GroceryTransactionService _transactionService;

    public GroceryEntryController(GroceryTransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    // GET ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_transactionService.GetGroceryTransactions(0, 10));
    }

    // GET BY ID
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var data = _transactionService.GetGroceryTransactionById(id);

        if (data == null)
            return NotFound("Data Not Found");

        return Ok(data);
    }

    // CREATE
    [HttpPost]
    public IActionResult Create([FromBody] GroceryTransactionModel grocery)
    {
        _transactionService.AddGroceryTrans(grocery);
        return Ok("Item Added Successfully");
    }

    // UPDATE
    [HttpPut]
    public IActionResult Update([FromBody] GroceryTransactionModel grocery)
    {
        _transactionService.UpdateGroceryTrans(grocery);
        return Ok("Updated Successfully");
    }

    // DELETE ✅ FIXED
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var data = _transactionService.GetGroceryTransactionById(id);

        if (data == null)
            return NotFound("Data Not Found");

        _transactionService.DeleteGroceryTrans(id);
        return Ok("Deleted Successfully");
    }
}