﻿using Todo.Business.Models;

namespace Todo.Business.Interfaces
{
    public interface ITodoRepository : IRepository<TodoModel>
    {
        Task<IEnumerable<TodoModel>> GetAllTodos(string userId);
        Task<TodoModel> GetTodo(Guid Id);
        
    }
}
