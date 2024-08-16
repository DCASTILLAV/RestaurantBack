using RestaurantBack.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Domain.RepositoryPattern
{
    public interface IProductRepository
    {
        IEnumerable<ProductResponseEntity> GetProduct(ProductRequestEntity parameter);
        ProductResponseEntity SetProduct(ProductRequestEntity parameter);
    }
}
