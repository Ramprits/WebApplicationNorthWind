using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.SampleDb.SampleEntities;

namespace WebApplicationNorthWind.Services
{
    public interface IProductRepositry
    {
        Product GetProduct(int ProductId);
        IEnumerable<Product> GetProducts();
        void AddProduct(Product Product);
        void DeleteProduct(Product ProductId);
        void UpdateProduct(Product ProductId);
        bool ProductExists(int ProductId);
        IEnumerable<ProductDescription> GetProductDescriptionsForProduct(int ProductId);
        ProductDescription GetProductDescriptionForProduct(int ProductId, int productDescriptionId);
        void AddProductDescriptionForProduct(int ProductId, ProductDescription productDescription);
        void UpdateProductDescriptionForProduct(ProductDescription productDescription);
        void DeleteProductDescription(ProductDescription productDescription);
        bool Save();
    }
}
