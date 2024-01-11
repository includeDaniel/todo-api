using Todo.Business.Interfaces;
using Todo.Business.Interfaces.Services;
using Todo.Business.Models;

namespace Todo.Business.Services
{
    public class TodoService : BaseService, ITodoService
    {

        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> Add(TodoModel todo)
        {
           await _todoRepository.Add(todo);
           return true;
        }

        public async Task<IEnumerable<TodoModel>> All(string userId) => await _todoRepository.GetAllTodos(userId.ToString()); 

        public Task<bool> Remove(string userId, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TodoModel> Show(string userId, Guid id) => await _todoRepository.GetTodo(userId.ToString(), id);

        public Task<bool> Update(string userId, TodoModel project)  
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _todoRepository.Dispose();
        }
    }
}
