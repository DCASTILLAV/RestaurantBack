using RestaurantBack.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Infrastructure.BusinessLogic.Sales
{
    public interface ISalesBL
    {
        IEnumerable<SalesResponseEntity> getSales(SalesRequestEntity parameter);
        SalesResponseEntity setSales(SalesRequestEntity parameter);
    }
}
