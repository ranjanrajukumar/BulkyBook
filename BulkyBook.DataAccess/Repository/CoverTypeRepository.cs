using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;
    
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    
        public void update(CoverType obj)
        {
            //  throw new NotImplementedException();
            _db.CoverTypes.Update(obj);
        }

    }
}
