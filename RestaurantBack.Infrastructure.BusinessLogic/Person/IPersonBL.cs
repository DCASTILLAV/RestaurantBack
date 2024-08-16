
using RestaurantBack.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Infrastructure.BusinessLogic.Person
{
    public interface IPersonBL
    {
        IEnumerable<PersonResponseEntity> GetPerson(PersonRequestEntity parameter);
        PersonResponseEntity SetPerson(PersonRequestEntity parameter);
    }
}
