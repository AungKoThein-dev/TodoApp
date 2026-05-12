using Microsoft.AspNetCore.Mvc;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;

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
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Add(string title)
    {
        return Ok(_service.Add(title));
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var item = _service.Get(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPut]
    public IActionResult Update(TodoItem item)
    {
        _service.Update(item);
        return NoContent();
    }
}