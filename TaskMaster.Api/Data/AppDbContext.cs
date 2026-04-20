using Microsoft.EntityFrameworkCore;
using TaskMaster.Api.Models;

namespace TaskMaster.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Esta es la tabla que se creará en SQL
    public DbSet<TodoTask> Tasks { get; set; }
}