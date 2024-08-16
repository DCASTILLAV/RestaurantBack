using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Domain.Entities.Person
{
    public class PersonRequestEntity
    {
        public int? option { get; set; }
        public string? names { get; set; }
        public string? surnames { get; set; }
        public string? cellPhone { get; set; }
        public string? email { get; set; }
        public string? codUser { get; set; }
        public string? password { get; set; }
        public int? idPerson { get; set; }
    }
}
