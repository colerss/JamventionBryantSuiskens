using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL.Data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, new()
    {
        protected DbContext Context { get; }
        public Repository(DbContext context)
        {
            this.Context = context;
        }
        public IEnumerable<T> Retrieve()
        {
            return Context.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> RetrieveAsync()
        {
          return await Context.Set<T>().ToListAsync();

        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void Edit(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }


        //uitbreiding

        public IEnumerable<T> Retrieve(Expression<Func<T, bool>> voorwaarden,
           params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (voorwaarden != null)
            {
                query = query.Where(voorwaarden);
            }
            return query.ToList();
        }
        public IEnumerable<T> Retrieve(Expression<Func<T, bool>> voorwaarden)
        {
            return Retrieve(voorwaarden, null).ToList();
        }

        public IEnumerable<T> Retrieve(params Expression<Func<T, object>>[] includes)
        {
            return Retrieve(null, includes).ToList();
        }



        public T RetrieveByPK<TPrimaryKey>(TPrimaryKey id)
        {
            return Context.Set<T>().Find(id);
        }
 
        public void AddOrEdit(T entity)
        {
            Context.Set<T>().AddOrUpdate(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
        public void Delete<TPrimaryKey>(TPrimaryKey id)
        {
            var entity = RetrieveByPK(id);
            Context.Set<T>().Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public int GetMaxPK(Func<T, int> columnSelector)
        {
   
            try
            {
                var maxId = Context.Set<T>().Max(columnSelector);
                return maxId;
            }
            catch (InvalidOperationException)
            {
                return 0;
                throw;
            }
          
            
        }

      
    }
}
