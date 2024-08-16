using RestaurantBack.Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Domain.Entities.Sales
{
    public class SalesResponseEntity : GeneralResponseEntity
    {
        public int? idOrder { get; set; }
        public string? nroOrder { get; set; }
        public string? observation { get; set; }
        public string? stateName { get; set; }
        public string? productName { get; set; }
        public double? productPrice { get; set; }
        public int? quantity { get; set; }
    }
}
