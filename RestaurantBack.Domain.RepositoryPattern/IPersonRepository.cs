using RestaurantBack.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Domain.RepositoryPattern
{
    public interface IPersonRepository
    {
        IEnumerable<PersonResponseEntity> GetPerson(PersonRequestEntity parameter);
        PersonResponseEntity SetPerson(PersonRequestEntity parameter);
    }
}
