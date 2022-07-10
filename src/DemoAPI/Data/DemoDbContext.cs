using DemoAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Data;

public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) {}
    public DbSet<Todo> Todo { get; set; }
}
