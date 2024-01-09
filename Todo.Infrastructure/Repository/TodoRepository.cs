using Microsoft.EntityFrameworkCore;
using Todo.Business.Interfaces;
using Todo.Business.Models;

namespace Todo.Infrastructure.Repository
{
    public class TodoRepository : Repository<TodoModel>, ITodoRepository
    {
        public TodoRepository(TodoContext context) : base(context) {}
          
       

        public async Task<IEnumerable<TodoModel>> GetAllTodos(string userId)
        {
            return await Db.Todos
                .AsNoTracking()
                .Where(u => u.UserId == userId)
                .ToListAsync();
        }
        public async Task<IEnumerable<TodoModel>> GetOneSpecificTodo(string userId, Guid Id)
        {
            return await Db.Todos
                .AsNoTracking()
                .Where(u => u.UserId == userId && u.Id == Id)
                .ToListAsync();
        }
    }
}
