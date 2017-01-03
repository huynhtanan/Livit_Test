using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Abc.Service.Services
{
	public interface IEntityService<TEntity> : IService where TEntity : class
	{
		void Create(TEntity entity);
		void Delete(TEntity entity);
		IQueryable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");
		void Update(TEntity entity);
		void Save();
	}
}
