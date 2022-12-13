using BulkyBook.Model;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void update(Product obj);

        
   //     void Save(Category obj); // not a use
   //     void Update(Category obj);// not a use
    }
}
