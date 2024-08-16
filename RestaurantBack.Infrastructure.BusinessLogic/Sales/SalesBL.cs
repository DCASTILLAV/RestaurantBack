using RestaurantBack.Domain.Entities.Sales;
using RestaurantBack.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Infrastructure.BusinessLogic.Sales
{
    public class SalesBL : ISalesBL
    {
        private IDapperUnitOfWork _unitOfWork;

        public SalesBL(IDapperUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SalesResponseEntity> getSales(SalesRequestEntity parameter)
        {
            return _unitOfWork.salesRespository.getSales(parameter);
        }

        public SalesResponseEntity setSales(SalesRequestEntity parameter)
        {
            return _unitOfWork.salesRespository.setSales(parameter);
        }
    }
}
