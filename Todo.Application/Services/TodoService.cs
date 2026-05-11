using Todo.Application.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Services;

public class TodoService : ITodoService
{
    private readonly List<TodoItem> _todos = new();
    private int _nextId = 1;

    public List<TodoItem> GetAll() => _todos;

    public TodoItem? Get(int id) =>
        _todos.FirstOrDefault(x => x.Id == id);

    public TodoItem Add(string title)
    {
        var item = new TodoItem
        {
            Id = _nextId++,
            Title = title,
            IsCompleted = false
        };

        _todos.Add(item);
        return item;
    }

    public void Delete(int id)
    {
        var item = _todos.FirstOrDefault(x => x.Id == id);
        if (item != null)
            _todos.Remove(item);
    }
}