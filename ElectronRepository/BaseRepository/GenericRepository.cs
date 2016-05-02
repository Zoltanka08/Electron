using ElectronRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ElectronRepository.BaseRepository
{
    public class GenericRepository<CEntity, TEntity> :
        IGenericRepository<TEntity> where TEntity : class where CEntity : DbContext, new()
    {
        private CEntity entities = new CEntity();
        public CEntity Context
        {

            get { return entities; }
            set { entities = value; }
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = entities.Set<TEntity>();

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

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                entities.Set<TEntity>().Attach(entityToDelete);
            }
            entities.Set<TEntity>().Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            var entry = Context.Entry<TEntity>(entityToUpdate);
            var pkey = entities.Set<TEntity>().Create().GetType().GetProperty("id").GetValue(entityToUpdate);

            if (entry.State == EntityState.Detached)
            {
                var set = Context.Set<TEntity>();
                TEntity attachedEntity = set.Find(pkey);
                if (attachedEntity != null)
                {
                    var attachedEntry = Context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entityToUpdate);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public virtual void Insert(TEntity entityToInsert)
        {
            entities.Set<TEntity>().Add(entityToInsert);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}