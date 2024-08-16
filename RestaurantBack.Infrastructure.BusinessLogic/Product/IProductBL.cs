using RestaurantBack.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Infrastructure.BusinessLogic.Product
{
    public interface IProductBL
    {
        IEnumerable<ProductResponseEntity> GetProduct(ProductRequestEntity parameter);
        ProductResponseEntity SetProduct(ProductRequestEntity parameter);
    }
}
