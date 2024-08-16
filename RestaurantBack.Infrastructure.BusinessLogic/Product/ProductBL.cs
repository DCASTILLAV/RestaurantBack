using RestaurantBack.Domain.Entities.Product;
using RestaurantBack.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Infrastructure.BusinessLogic.Product
{
    public class ProductBL : IProductBL
    {
        private IDapperUnitOfWork _unitOfWork;

        public ProductBL(IDapperUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductResponseEntity> GetProduct(ProductRequestEntity parameter)
        {
            return _unitOfWork.productRepository.GetProduct(parameter);
        }

        public ProductResponseEntity SetProduct(ProductRequestEntity parameter)
        {
            return _unitOfWork.productRepository.SetProduct(parameter);
        }
    }
}
