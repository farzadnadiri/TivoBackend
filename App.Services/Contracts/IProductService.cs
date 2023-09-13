using System.Collections.Generic;
using App.Entities;

namespace App.Services.Contracts
{
    public interface IProductService
    {
        void AddNewProduct(Product product);
        IList<Product> GetAllProducts();
    }
}