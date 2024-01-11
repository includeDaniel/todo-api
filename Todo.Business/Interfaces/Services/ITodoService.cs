using Todo.Business.Models;

namespace Todo.Business.Interfaces.Services
{
    public interface ITodoService : IDisposable
    {
        Task<IEnumerable<TodoModel>> All(string userId);
        Task<TodoModel> Show(string userId, Guid id);
        Task<bool> Add(TodoModel todo);
        Task<bool> Update(string userId, TodoModel project);
        Task<bool> Remove(string userId,Guid id);
    }
}

