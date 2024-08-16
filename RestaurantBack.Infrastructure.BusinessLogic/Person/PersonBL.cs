using RestaurantBack.Domain.Entities.Person;
using RestaurantBack.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Infrastructure.BusinessLogic.Person
{
    public class PersonBL : IPersonBL
    {
        private IDapperUnitOfWork _unitOfWork;

        public PersonBL(IDapperUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PersonResponseEntity> GetPerson(PersonRequestEntity parameter)
        {
            return _unitOfWork.personRepository.GetPerson(parameter);
        }

        public PersonResponseEntity SetPerson(PersonRequestEntity parameter)
        {
            return _unitOfWork.personRepository.SetPerson(parameter);
        }
    }
}
