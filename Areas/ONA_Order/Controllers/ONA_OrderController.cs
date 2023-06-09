using Microsoft.AspNetCore.Mvc;
using OnlineAuction.BAL;

namespace OnlineAuction.Areas.ONA_Order.Controllers
{
    [CheckAccess]
    [Area("ONA_Order")]
    [Route("ONA_Order/[controller]/[action]")]
    public class ONA_OrderController : Controller
    {
        public IActionResult Index()
        {
            return View("ONA_OrderList");
        }
    }
}
