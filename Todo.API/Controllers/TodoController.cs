using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Controllers.Models;
using Todo.Business.Interfaces;
using Todo.Business.Interfaces.Services;
using Todo.Business.Models;
using AutoMapper;

namespace Todo.API.Controllers;

[Route("api/TodoItemsController")]
[ApiController]
[Authorize]
public class TodoController : MainController
{
    private readonly ITodoService _todoService;
    private readonly IMapper _mapper;

    public TodoController(ITodoService todoService, INotify notifier, IMapper mapper) : base(notifier)
    {
        _todoService = todoService;
        _mapper = mapper;   
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
    public async Task<ActionResult<TodoModel>> Show(Guid id)
    {
        var todo = await _todoService.Show(id);

        if (todo == null) return NotFound();
        return HandleResponse(todo);
    }
    // </snippet_GetByID>

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, TodoViewModel todo)
    {

        if(id.ToString() != todo.Id)
            {
            NotifyError("Incorret Id");
            return HandleResponse(todo);
        }

        if (!ModelState.IsValid)
        {
            NotifyError("ModelState is invalid");
            return HandleResponse(ModelState);
        }

        var todoItem = new TodoModel
        {
            IsComplete = todo.IsCompleted,
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
    public async Task<ActionResult<TodoViewModel>> Add(TodoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            NotifyError("ModelState is invalid");
            return HandleResponse(ModelState);
        }

        var todo = new TodoModel
        {
            IsComplete = false,
            Name = model.Name,
            UserId = model.UserId
        };

        
        await _todoService.Add(todo);
        return HandleResponse(model);
    }
    // </snippet_Create>

    // DELETE: api/TodoItems/5
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {

        var projectViewModel = await GetTodo(id);

        if (projectViewModel == null) return NotFound();

        await _todoService.Remove(id);
        return HandleResponse("Task with id: " + id + " removed with success");
    }


    private async Task<TodoViewModel> GetTodo(Guid id) => _mapper.Map<TodoViewModel>(await _todoService.Show(id));

}