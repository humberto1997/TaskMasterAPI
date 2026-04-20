using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Api.Data;
using TaskMaster.Api.Models;

namespace TaskMaster.Api.Controllers;

[ApiController]
[Route("api/[controller]")] // La dirección será: localhost:xxxx/api/tasks
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    // Inyección de Dependencia: Traemos la conexión a la DB
    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/tasks (Ver todas)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    // POST: api/tasks (Crear una nueva)
    [HttpPost]
    public async Task<ActionResult<TodoTask>> CreateTask(TodoTask task)
    {
        try
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error en el servidor: {ex.Message}");
        }
    }
}