using MusicDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
namespace MusicDatabase.DAL
{
    public class FakeMusicDatabaseRepo<TEntity> : IMusicDatabaseRep<TEntity> where TEntity : IEntityModel
    {
                                                             
        List<TEntity> entities;

        public FakeMusicDatabaseRepo(List<TEntity> entitiesList)
        {
            entities = entitiesList;
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            var query = entities.AsQueryable<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return (from e in entities
                    where e.ID == (int)id
                    select e).FirstOrDefault();
            // Note: We constrined TEntity to be a subclass of IEntityModel
            // just so that we could implement this method. If we hadn't made 
            // TEntity a subclass of IEntityModel, then we could not have used
            // e.ID in the where clause of our query.
        }

        public virtual void Insert(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual void Delete(object id)
        {

            TEntity entityToDelete = GetByID(id);
            Delete(entityToDelete);
        }
    }
}