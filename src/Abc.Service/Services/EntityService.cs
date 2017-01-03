using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Dal.Repository;
using Abc.Dal.UnitOfWork;
using System.Linq.Expressions;

namespace Abc.Service.Services
{	
	public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class
	{
		IUnitOfWork _unitOfWork;
		IRepository<TEntity> _repository;
		public EntityService(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
		{
			_unitOfWork = unitOfWork;
			_repository = repository;
		}
		public virtual void Create(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			_repository.Create(entity);
		}


		public virtual void Update(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");
			_repository.Update(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");
			_repository.Delete(entity);			
		}

		public virtual IQueryable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			return _repository.Get(filter, orderBy, includeProperties);
		}
		public virtual void Save()
		{
			_unitOfWork.Save();
		}
	}
}
