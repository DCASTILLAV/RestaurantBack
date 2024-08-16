using RestaurantBack.Domain.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Domain.UnitOfWork
{
    public interface IDapperUnitOfWork
    {
        IProductRepository productRepository { get; }
        IPersonRepository personRepository { get; }
        ISalesRespository salesRespository { get; }
    }
}
