using WebApplicationTraining.Dtos;

namespace WebApplicationTraining.Repositories
{
    public interface IProductRepository
    {
        // Create a new product 
        void CreateProduct(DtoProduct product);
        // Read all products 
        List<DtoProduct> GetAllProducts();
        // Read a single product by ID 
        DtoProduct GetProductById(int productId);
        // Update an existing product 
        void UpdateProduct(DtoProduct product);
        // Delete a product by ID 
        void DeleteProduct(int productId);


    }
}
