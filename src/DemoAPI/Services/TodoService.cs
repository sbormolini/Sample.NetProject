using DemoAPI.Data;
using DemoAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services;

public class TodoService : ITodoService
{
    private readonly DemoDbContext _context;
    public TodoService(DemoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        return await _context.Todo.ToListAsync();
    }

    public async Task SaveAsync(Todo newTodo)
    {
        _context.Todo.Add(newTodo);
        await _context.SaveChangesAsync();
    }
}
