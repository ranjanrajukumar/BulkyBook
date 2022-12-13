using BulkyBook.Model;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void update(Category obj);

        
   //     void Save(Category obj); // not a use
   //     void Update(Category obj);// not a use
    }
}
