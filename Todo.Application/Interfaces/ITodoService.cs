using Todo.Domain.Entities;

namespace Todo.Application.Interfaces;

public interface ITodoService
{
    List<TodoItem> GetAll();
    TodoItem? Get(int id);
    TodoItem Add(string title);
    void Delete(int id);
    void Update(TodoItem item);
}