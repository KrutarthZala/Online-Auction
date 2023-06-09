using Microsoft.AspNetCore.Mvc;
using OnlineAuction.BAL;

namespace OnlineAuction.Areas.ONA_Bid.Controllers
{
    [CheckAccess]
    [Area("ONA_Bid")]
    [Route("ONA_Bid/[controller]/[action]")]
    public class ONA_BidController : Controller
    {
        public IActionResult Index()
        {
            return View("ONA_BidList");
        }
    }
}
