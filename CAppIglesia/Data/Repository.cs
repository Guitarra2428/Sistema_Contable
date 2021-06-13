using CAppIglesia.Data.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext dbContext;
        internal DbSet<T> dbset;
        public Repository( DbContext context)
        {
            dbContext = context;
            dbset = context.Set<T>();

        }

        public void Add(T entidad)
        {
            dbset.Add(entidad);
        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> fIter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrdeBy = null, string IncludeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (fIter !=null)
            {
               query = query.Where(fIter);
            }

            if (IncludeProperties !=null)
            {
                foreach (var IncludeProperty in IncludeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProperty);
                }
            }

            if (OrdeBy !=null)
            {
                return query = OrdeBy(query);

            }
            return query.ToList();
        }

        public T GetDefault(Expression<Func<T, bool>> fIter = null, string IncludeProperties = null)
        {
            IQueryable<T> query = dbset;

            if (fIter != null)
            {
                query = query.Where(fIter);
            }

            if (IncludeProperties != null)
            {
                foreach (var IncludeProperty in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public T GetT(int id)
        {
            return dbset.Find(id);
        }

        public void Remove(int id)
        {
          T elimnar = dbset.Find(id);
           Remove(elimnar);
        }

        public void Remove(T entidad)
        {
           dbset.Remove(entidad);
        }
    }
}
