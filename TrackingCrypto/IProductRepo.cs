using ASP.NetCoreE1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ASP.NetCoreE1
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);

        public void UpdateProduct(Product product);

        public void InsertProduct(Product productToInsert);

        public IEnumerable<Category> GetCategories();

        public Product AssignCategory();

        public void DeleteProduct(Product product); 


    }
}
