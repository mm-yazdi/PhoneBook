using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<PhoneBookEntry> phoneBookEntries { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PhoneBookEntry>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
				entity.Property(e=>e.PhoneNumber).IsRequired().HasMaxLength(11);
				entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
			});
		}
	}
}
