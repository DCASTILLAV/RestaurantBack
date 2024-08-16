using RestaurantBack.Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Domain.Entities.Product
{
    public class ProductResponseEntity : GeneralResponseEntity
    {
        public int? idProduct {  get; set; }
        public string? productName { get; set; }
        public double? productPrice { get; set; }
    }
}
