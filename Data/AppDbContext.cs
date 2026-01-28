using Microsoft.EntityFrameworkCore;

/// <summary>
/// this class is the ORM that maps the objects described in our csharp classes
/// to tables in the SQLite db
/// </summary>

public class AppDbContext : DbContext
{
    //constructor calling the constructor of the super class DbContext
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    //tables of the SQL db
    public DbSet<Ticket> Tickets {get; set;}
}