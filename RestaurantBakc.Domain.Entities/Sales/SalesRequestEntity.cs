using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Domain.Entities.Sales
{
    public class SalesRequestEntity
    {
        public int? option {  get; set; }
        public string? formatJson { get; set; }
        public string? observation { get; set; }
        public int? idState { get; set; }
        public int? idPerson { get; set; }
        public string? codUser { get; set; }
        public int? idOrder { get; set; }
    }
}
