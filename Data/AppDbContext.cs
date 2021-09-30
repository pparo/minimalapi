using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Data
{
    public class AppDbContext : DbContext
		{
			public DbSet<MyClass> MyClasses { get; set; }

			protected override void OnConfiguring(DbContextOptionsBuilder options)
				=> options.UseSqlite("DataSource=app.db;Cache=Shared");
		}
}