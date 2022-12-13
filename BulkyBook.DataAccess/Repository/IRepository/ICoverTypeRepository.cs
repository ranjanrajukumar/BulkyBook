using BulkyBook.Model;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void update(CoverType obj);

        
   //     void Save(Category obj); // not a use
   //     void Update(Category obj);// not a use
    }
}
