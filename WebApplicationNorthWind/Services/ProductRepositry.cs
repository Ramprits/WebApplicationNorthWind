using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.SampleDb.SampleEntities;

namespace WebApplicationNorthWind.Services
{
    public class ProductRepositry : IProductRepositry
    {
        private readonly SampledbContext _context;
        public ProductRepositry(SampledbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product Product)
        {
            _context.Add(Product);
        }

        public void AddProductDescriptionForProduct(int ProductId, ProductDescription productDescription)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product ProductId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductDescription(ProductDescription productDescription)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int ProductId)
        {
            return _context.Product.FirstOrDefault(x => x.ProductId == ProductId);
        }

        public ProductDescription GetProductDescriptionForProduct(int ProductId, int productDescriptionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDescription> GetProductDescriptionsForProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Product.OrderByDescending(x => x.Name).ToList();
        }

        public bool ProductExists(int ProductId)
        {
            return _context.Product.Any(x => x.ProductId == ProductId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateProduct(Product ProductId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductDescriptionForProduct(ProductDescription productDescription)
        {
            throw new NotImplementedException();
        }
    }
}
