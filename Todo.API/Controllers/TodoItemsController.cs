using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.API.Controllers.Models;
using Todo.Business.Interfaces;
using Todo.Business.Interfaces.Services;
using Todo.Business.Models;
using Todo.Infrastructure;
using Todo.Infrastructure.Repository;

namespace Todo.API.Controllers;

[Route("api/TodoItemsController")]
[ApiController]
[Authorize]
public class TodoItemsController : ControllerBase
{
    private readonly TodoContext _context;
    private readonly ITodoService _todoService;

    public TodoItemsController(TodoContext context, ITodoService todoService)
    {
        _context = context;
        _todoService = todoService;
    }

    // GET: api/TodoItems
    [Authorize(Policy = "Todo.GetAll")]
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<IEnumerable<TodoModel>>> All(Guid userId)
    {
        return Ok(await _todoService.All(userId.ToString())); 
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    [HttpGet("{id:guid}/{userId:guid}")]
    public async Task<ActionResult<TodoModel>> Show(Guid id, Guid userId)
    {
        var todoItem = await _todoService.Show(userId.ToString(), id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return Ok(todoItem);
    }
    // </snippet_GetByID>

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id:guid}/{userId:guid}")]
    public async Task<IActionResult> Update(Guid id, TodoModel todo, Guid userId)
    {
        if (id != todo.Id && userId.ToString() != todo.UserId)
        {
            return BadRequest();
        }

        var todoItem = await _context.Todos.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Name = todo.Name;
        todoItem.IsComplete = todo.IsComplete;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }
    // </snippet_Update>

    // POST: api/TodoItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost("{userId:guid}")]
    public async Task<ActionResult<TodoViewModel>> Add(Guid userId, TodoViewModel todo)
    {
        var todoItem = new TodoModel
        {
            IsComplete = todo.IsComplete,
            Name = todo.Name,
            UserId = userId.ToString()
        };

        _context.Todos.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Show),
            new { id = todoItem.Id },
            todoItem);
    }
    // </snippet_Create>

    // DELETE: api/TodoItems/5
    [HttpDelete("{id:guid}/{userId:guid}")]
    public async Task<IActionResult> Remove(Guid id, Guid userId)
    {
        var todoItem = await _context.Todos.FindAsync(id);
        if (todoItem.UserId != userId.ToString())
        {
            return BadRequest();
        }
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.Todos.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TodoItemExists(Guid id)
    {
        return _context.Todos.Any(e => e.Id == id);
    }
}