using RestaurantBack.Domain.RepositoryPattern;
using RestaurantBack.Domain.UnitOfWork;
using RestaurantBack.Infrastructure.DapperRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Infrastructure.UnitOfWork
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {

        public IProductRepository productRepository { get; set; }

        public IPersonRepository personRepository { get; set; }

        public ISalesRespository salesRespository { get; set; }

        public DapperUnitOfWork(string connectionString)
        {
            productRepository = new ProductRepository(connectionString);
            personRepository = new PersonRepository(connectionString);
            salesRespository = new SalesRepository(connectionString);
        }
    }
}
