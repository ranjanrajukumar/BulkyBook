using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
    
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    
        public void update(Category obj)
        {
            //  throw new NotImplementedException();
            _db.Categories.Update(obj);
        }

    }
}
