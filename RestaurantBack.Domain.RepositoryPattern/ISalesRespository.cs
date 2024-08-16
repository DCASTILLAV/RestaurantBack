using RestaurantBack.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Domain.RepositoryPattern
{
    public interface ISalesRespository
    {
        IEnumerable<SalesResponseEntity> getSales(SalesRequestEntity parameter);
        SalesResponseEntity setSales(SalesRequestEntity parameter);
    }
}
