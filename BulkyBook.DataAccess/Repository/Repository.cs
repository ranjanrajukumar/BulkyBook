using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.ShoppingCarts.Include(u => u.Product).Include(u=>u.CoverType);
            this.dbSet = _db.Set<T>();
           
        }

        //void IRepository<T>.Add(T entity)
        //{
        //    dbSet.Add(entity);
        //  //  _db.SaveChanges();
        //}
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        IEnumerable<T> IRepository<T>.GetAll(string? includeProperties = null)
        {
            // throw new NotImplementedException();

            IQueryable<T> query = dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();

        }

        T IRepository<T>.GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            //throw new NotImplementedException();
            IQueryable<T> query = dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        void IRepository<T>.Remove(T entity)
        {
           // throw new NotImplementedException();
           dbSet.Remove(entity);
        }

        void IRepository<T>.RemoveRange(IEnumerable<T> entity)
        {
         //   throw new NotImplementedException();

            dbSet.RemoveRange(entity);
        }
    }
}
