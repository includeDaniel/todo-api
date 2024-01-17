using Todo.Business.Interfaces;
using Todo.Business.Interfaces.Services;
using Todo.Business.Models;
using Todo.Business.Models.Validations;

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

            if (!ExecuteValidation(new TodoValidation(), todo)) return false;

            if (_todoRepository.Find(t => t.Name == todo.Name).Result.Any())
            {
                Notify("Todo with this name already exists");
                return false;
            }

            //if (DateTime.Compare(project.FinalDate, project.InitialDate) <= 0)
            //{
            //    Notify("A data final deve ser maior que a data inicial");
            //    return false;
            //}

           await _todoRepository.Add(todo);
           return true;
        }

        public async Task<IEnumerable<TodoModel>> All(string userId) => await _todoRepository.GetAllTodos(userId.ToString()); 

        public async Task<bool> Remove(Guid id)
        {
            await _todoRepository.Remove(id);
            return true;
        }

        public async Task<TodoModel> Show(string userId, Guid id) => await _todoRepository.GetTodo(userId.ToString(), id);

        public async Task<bool> Update(Guid id, TodoModel todo)  
        {

            if (!ExecuteValidation(new TodoValidation(), todo)) return false;

            if (_todoRepository.Find(p => p.Name == todo.Name && p.Id != todo.Id).Result.Any())
            {
                Notify("Todo with this name already exists");
                return false;
            }

            //if (DateTime.Compare(project.FinalDate, project.InitialDate) <= 0)
            //{
            //    Notify("A data final deve ser maior que a data inicial");
            //    return false;
            //}

            await _todoRepository.Update(todo);
            return true;

        }
        public void Dispose()
        {
            _todoRepository.Dispose();
        }
    }
}
