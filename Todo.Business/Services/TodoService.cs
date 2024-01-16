using Todo.Business.Interfaces;
using Todo.Business.Interfaces.Services;
using Todo.Business.Models;

namespace Todo.Business.Services
{
    public class TodoService : BaseService, ITodoService
    {

        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository, INotify notify) : base(notify)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> Add(TodoModel todo)
        {
           await _todoRepository.Add(todo);
           return true;
        }

        public async Task<IEnumerable<TodoModel>> All(string userId) => await _todoRepository.GetAllTodos(userId.ToString()); 

        public async Task<bool> Remove(Guid id)
        {

            //var todoItem = await _todoRepository.GetById(id);
            //if (todoItem == null)
            //{
            //    return NotFound();
            //}
            await _todoRepository.Remove(id);
            return true;
        }

        public async Task<TodoModel> Show(string userId, Guid id) => await _todoRepository.GetTodo(userId.ToString(), id);

        public async Task<bool> Update(Guid id, TodoModel todo)  
        {
        
            //var todoItem = await _todoRepository.GetById(id);
            //if (todoItem == null)
            //{2
            //    return NotFound();
            //}

            //todoItem.Name = todo.Name;
            //todoItem.IsComplete = todo.IsComplete;

            //try
            //{
                await _todoRepository.Update(todo);
            //}
            //catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            //{
            //    return NotFound();
            //}
            return true;

        }
        public void Dispose()
        {
            _todoRepository.Dispose();
        }
    }
}
