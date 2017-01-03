using System;
using Microsoft.EntityFrameworkCore;
using Abc.Dal.Models;

namespace Abc.Dal.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private DatabaseContext _dbContext;

		/// <summary>
		/// Initializes a new instance of the UnitOfWork class.
		/// </summary>
		/// <param name="context">The object context</param>
		public UnitOfWork(DatabaseContext context)
		{
			_dbContext = context;
		}
		public DatabaseContext DbContext
		{
			get { return _dbContext; }
		}
		public void Save()
		{
			DbContext.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					DbContext.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
