using Microsoft.AspNetCore.Mvc;
using RestaurantBack.Domain.Entities.Person;
using RestaurantBack.Domain.Entities.Product;
using RestaurantBack.Domain.Entities.Sales;
using RestaurantBack.Infrastructure.BusinessLogic.Person;
using RestaurantBack.Infrastructure.BusinessLogic.Product;
using RestaurantBack.Infrastructure.BusinessLogic.Sales;

namespace RestaurantBack.Controllers
{
    [ApiController]
    [Route("RestaurantApi")]
    [Produces("application/json")]
    public class RestaurantController : Controller
    {
        private readonly IProductBL _productBL;
        private readonly IPersonBL _personBL;
        private readonly ISalesBL _salesBL;

        public RestaurantController(IProductBL productBL, IPersonBL personBL, ISalesBL salesBL)
        {
            _productBL = productBL;
            _personBL = personBL;
            _salesBL = salesBL;
        }

        #region PRODUCT
        [HttpPost]
        [Route("getProduct")]
        public ActionResult getProduct(ProductRequestEntity parameter)
        {
            return Ok(_productBL.GetProduct(parameter));
        }

        [HttpPost]
        [Route("setProduct")]
        public ActionResult setProduct(ProductRequestEntity parameter)
        {
            return Ok(_productBL.SetProduct(parameter));
        }
        #endregion

        #region PERSON
        [HttpPost]
        [Route("getPerson")]
        public ActionResult getPerson(PersonRequestEntity parameter)
        {
            return Ok(_personBL.GetPerson(parameter));
        }

        [HttpPost]
        [Route("setPerson")]
        public ActionResult setPerson(PersonRequestEntity parameter)
        {
            return Ok(_personBL.SetPerson(parameter));
        }
        #endregion


        #region SALES
        [HttpPost]
        [Route("getSales")]
        public ActionResult getSales(SalesRequestEntity parameter)
        {
            return Ok(_salesBL.getSales(parameter));
        }

        [HttpPost]
        [Route("setSales")]
        public ActionResult setSales(SalesRequestEntity parameter)
        {
            return Ok(_salesBL.setSales(parameter));
        }
        #endregion

    }
}
