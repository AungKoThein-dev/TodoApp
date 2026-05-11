using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoController(ITodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Create(CreateTodoRequest request)
    {
        var item = _service.Add(request.Title);
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}