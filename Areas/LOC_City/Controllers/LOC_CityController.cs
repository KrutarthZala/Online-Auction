using AddressBook.DAL;
using Microsoft.AspNetCore.Mvc;
using OnlineAuction.BAL;
using System.Configuration;
using System.Data;

namespace OnlineAuction.Areas.LOC_City.Controllers
{
    [CheckAccess]
    [Area("LOC_City")]
    [Route("LOC_City/[controller]/[action]")]

    public class LOC_CityController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        private IConfiguration Configuration;
        public LOC_CityController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalLOC.dbo_PR_LOC_City_SelectAll();

            return View("LOC_CityList", dt);
        }
        #endregion

        // This is pending !!!
    }
}
