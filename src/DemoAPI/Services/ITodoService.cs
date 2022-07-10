using DemoAPI.Data.Entities;

namespace DemoAPI.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();
        Task SaveAsync(Todo newTodo);
    }
}