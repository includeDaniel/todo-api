using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.API.Controllers.Models;
using Todo.Business.Interfaces;
using Todo.Business.Interfaces.Services;
using Todo.Business.Models;
using Todo.Infrastructure;

namespace Todo.API.Controllers;

[Route("api/TodoItemsController")]
[ApiController]
[Authorize]
public class TodoController : MainController
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService, INotify notifier) : base(notifier)
    {
        _todoService = todoService;
    }

    // GET: api/TodoItems
    [Authorize(Policy = "Todo.GetAll")]
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<IEnumerable<TodoModel>>> All(Guid userId)
    {
        return HandleResponse(await _todoService.All(userId.ToString()));
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    [HttpGet("{id:guid}/{userId:guid}")]
    public async Task<ActionResult<TodoModel>> Show(Guid id, Guid userId)
    {
        var todoItem = await _todoService.Show(userId.ToString(), id);

        if (todoItem == null)
        {
            return HandleResponse();
        }

        return HandleResponse(todoItem);
    }
    // </snippet_GetByID>

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, TodoViewModel todo)
    {
        var todoItem = new TodoModel
        {
            IsComplete = todo.IsComplete,
            Name = todo.Name,
            UserId = todo.UserId
        };

        todoItem.Id = new Guid(todo.Id);


        await _todoService.Update( id, todoItem);


        return HandleResponse();
    }
    // </snippet_Update>

    // POST: api/TodoItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost]
    public async Task<ActionResult<TodoViewModel>> Add(TodoViewModel todo)
    {
        var todoItem = new TodoModel
        {
            IsComplete = todo.IsComplete,
            Name = todo.Name,
            UserId = todo.UserId
        };


        await _todoService.Add(todoItem);

        return HandleResponse(todo);
    }
    // </snippet_Create>

    // DELETE: api/TodoItems/5
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {

        await _todoService.Remove(id);
        return HandleResponse("Task with id: " + id + " removed with success");
    }


}