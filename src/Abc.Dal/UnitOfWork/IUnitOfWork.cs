using System;
using Abc.Dal.Models;

namespace Abc.Dal.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		DatabaseContext DbContext { get; }
		void Save();
	}
}
