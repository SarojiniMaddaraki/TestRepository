using GroceryApp.Model;
using GroceryApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_userService.GetUsers(0, 10));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var user = _userService.GetUserById(id);

        if (user == null)
            return NotFound("User Not Found");

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(UserModel user)
    {
        _userService.AddUser(user);
        return Ok("User Added");
    }

    [HttpPut]
    public IActionResult Update(UserModel user)
    {
        _userService.UpdateUser(user);
        return Ok("Updated Successfully");
    }
    [Authorize(Roles ="Admin")]
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var user = _userService.GetUserById(id);

        if (user == null)
            return NotFound("User Not Found");

        _userService.DeleteUser(id);
        return Ok("Deleted Successfully");
    }
}