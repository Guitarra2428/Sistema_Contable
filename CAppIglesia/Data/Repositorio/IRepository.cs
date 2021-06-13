using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CAppIglesia.Data.Repositorio
{
   public interface IRepository<T> where T : class
    {

        T GetT(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> fIter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrdeBy=null,
            string IncludeProperties=null
            
            );
        T GetDefault(
             Expression<Func<T, bool>> fIter = null,
            string IncludeProperties = null
            );

        void Add( T entidad);
        void Remove(int id);
        void Remove(T entidad);

        
    }
}
