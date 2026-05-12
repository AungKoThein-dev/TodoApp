using Todo.Application.Interfaces;
using Todo.Domain.Entities;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Services;

public class TodoService : ITodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public List<TodoItem> GetAll()
    {
        return _context.Todos.ToList();
    }

    public TodoItem Add(string title)
    {
        var item = new TodoItem
        {
            Title = title
        };

        _context.Todos.Add(item);
        _context.SaveChanges();

        return item;
    }

    public void Delete(int id)
    {
        var item = _context.Todos.FirstOrDefault(x => x.Id == id);

        if (item != null)
        {
            _context.Todos.Remove(item);
            _context.SaveChanges();
        }
    }

    public void Update(TodoItem item)
    {
        var existingItem = _context.Todos.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Title = item.Title;
            existingItem.IsCompleted = item.IsCompleted;
            _context.SaveChanges();
        }
    }

    public TodoItem? Get(int id)
    {
        return _context.Todos.FirstOrDefault(x => x.Id == id);
    }
}
     