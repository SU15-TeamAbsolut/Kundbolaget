using MVCCMS.Models.EntityModels;

namespace MVCCMS.EntityFramework.Repositories
{
    public interface IStoreRepository
    {
        Product[] GetProducts();
        Product GetProduct(int id);
        void CreateProduct(Product newProduct);
        void UpdateProduct(Product updatedProduct);
        void DeleteProduct(int id);
    }
}