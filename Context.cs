using Microsoft.EntityFrameworkCore;

namespace Library_Manager;

public class Context: DbContext
{
    public Context()
    { 
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
        
        //Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=library_manager;username=postgres;password=1846Awlq;");
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Reader> Readers { get; set; }
    public DbSet<Borrow> Borrows { get; set; }
}