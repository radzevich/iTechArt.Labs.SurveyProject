using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SurveyApp.DAL.Repositories.Interfaces
{ 
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entityToInsert);

        TEntity GetById(object id);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
