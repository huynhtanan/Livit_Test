using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Security.Principal;

namespace Abc.Dal.Models
{
	public partial class DatabaseContext : DbContext
	{
		public DbSet<Absence> Absence { get; set; }
		public DbSet<AbsenceState> AbsenceState { get; set; }
		public DbSet<AbsenceType> AbsenceType { get; set; }
		public DbSet<Employee> Employee { get; set; }
		public DbSet<EmployeeStatus> EmployeeStatus { get; set; }
		public DbSet<EmployeeType> EmployeeType { get; set; }
		public DbSet<Employee_Role> Employee_Role { get; set; }
		public DbSet<Role> Role { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Datasource=Abc.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.HasOne(p => p.CreatedBy)
				.WithOne()
				.HasForeignKey<Employee>(b => b.CreatedById);

			modelBuilder.Entity<Employee>()
				.HasOne(p => p.UpdatedBy)
				.WithOne()
				.HasForeignKey<Employee>(b => b.UpdatedById);

			//modelBuilder.Entity<Employee>()
			//	.HasOne(p => p.EmployeeStatus)
			//	.WithOne()
			//	.HasForeignKey<Employee>(b => b.EmployeeStatusId);

			//modelBuilder.Entity<Employee>()
			//	.HasOne(p => p.EmployeeType)
			//	.WithOne()
			//	.HasForeignKey<Employee>(b => b.EmployeeTypeId);
		}
		public override int SaveChanges()
		{
			var modifiedEntries = ChangeTracker.Entries()
				.Where(x => x.Entity is IBaseEntity
					&& (x.State == EntityState.Added || x.State == EntityState.Modified));

			foreach (var entry in modifiedEntries)
			{
				IBaseEntity entity = entry.Entity as IBaseEntity;
				if (entity != null)
				{
					DateTime now = DateTime.Now;

					if (entry.State == EntityState.Added)
					{
						entity.CreatedDate = now;
					}
					else
					{
						base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
					}
					
					entity.UpdatedDate = now;
				}
			}

			return base.SaveChanges();
		}
	}
}