using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Domain.Entities.Product
{
    public class ProductRequestEntity
    {
        public int? option { get; set; }
        public string? productName { get; set; }
        public double? productPrice { get; set; }
    }
}
