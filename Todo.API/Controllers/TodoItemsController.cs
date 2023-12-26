using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.API.Controllers.Models;
using TodoApi.Models;

namespace Todo.API.Controllers;

[Route("api/TodoItemsController")]
[ApiController]
[Authorize]
public class TodoItemsController : ControllerBase
{
    private readonly TodoContext _context;

    public TodoItemsController(TodoContext context)
    {
        _context = context;
    }

    // GET: api/TodoItems
    [Authorize(Policy = "Todo.GetAll")]
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<IEnumerable<TodoItem>>> All(Guid userId)
    {

        return await _context.TodoItems
            .Select(x => x)
            .Where(x => x.UserId == userId.ToString())
            .ToListAsync();
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    [HttpGet("{id:long}/{userId:guid}")]
    public async Task<ActionResult<TodoItemDTO>> Show(long id, Guid userId)
    {
        var todoItem = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId.ToString());

        if (todoItem == null)
        {
            return NotFound();
        }

        return ItemToDTO(todoItem);
    }
    // </snippet_GetByID>

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id:long}/{userId:guid}")]
    public async Task<IActionResult> Update(long id, TodoItem todo, Guid userId)
    {
        if (id != todo.Id && userId.ToString() != todo.UserId)
        {
            return BadRequest();
        }

        var todoItem = await _context.TodoItems.FindAsync(id);
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
        var todoItem = new TodoItem
        {
            IsComplete = todo.IsComplete,
            Name = todo.Name,
            UserId = userId.ToString()
        };

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Show),
            new { id = todoItem.Id },
            ItemToDTO(todoItem));
    }
    // </snippet_Create>

    // DELETE: api/TodoItems/5
    [HttpDelete("{id:long}/{userId:guid}")]
    public async Task<IActionResult> Remove(long id, Guid userId)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);
        if (todoItem.UserId != userId.ToString())
        {
            return BadRequest();
        }
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TodoItemExists(long id)
    {
        return _context.TodoItems.Any(e => e.Id == id);
    }

    private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
       new TodoItemDTO
       {
           Id = todoItem.Id,
           Name = todoItem.Name,
           IsComplete = todoItem.IsComplete
       };
}