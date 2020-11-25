using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL.Data.Repository
{
    public interface IRepository<T>
        where T : class, new()
    {
        IEnumerable<T> Retrieve();
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);


        //uitbreiding
        IEnumerable<T> Retrieve(Expression<Func<T, bool>> voorwaarden);
        IEnumerable<T> Retrieve(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> Retrieve(Expression<Func<T, bool>> voorwaarden,
            params Expression<Func<T, object>>[] includes);


        //handige functies
        T RetrieveByPK<TPrimaryKey>(TPrimaryKey id);
        void AddOrEdit(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete<TPrimaryKey>(TPrimaryKey id);
        void DeleteRange(IEnumerable<T> entities);

        int GetMaxPK(Func<T, int> columnSelector);


    }
}
