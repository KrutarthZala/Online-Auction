using OnlineAuction.DAL;
using Microsoft.AspNetCore.Mvc;
using OnlineAuction.BAL;
using OnlineAuction.Areas.SEC_User.Models;
using System.Data;

namespace OnlineAuction.Areas.SEC_User.Controllers
{
   
    [Area("SEC_User")]
    [Route("SEC_User/[controller]/[action]")]
    public class SEC_UserController : Controller
    {
        private IConfiguration Configuration;
        public SEC_UserController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Login(SEC_UserModel modelSEC_User)
        {
            string connstr = this.Configuration.GetConnectionString("myConnectionString");
            string error = null;
            if (modelSEC_User.UserName == null)
            {
                error += "User Name is required";
            }
            if (modelSEC_User.UserPassword == null)
            {
                error += "<br/>Password is required";
            }

            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("Login");
            }
            else
            {
                SEC_DAL dal = new SEC_DAL();
                DataTable dt = dal.dbo_PR_SEC_User_SelectByUserNamePassword(modelSEC_User.UserName, modelSEC_User.UserPassword);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("UserPassword", dr["UserPassword"].ToString());
                        //HttpContext.Session.SetString("UserEmail", dr["UserEmail"].ToString());
                        //HttpContext.Session.SetString("LastName", dr["LastName"].ToString());
                        //HttpContext.Session.SetString("PhotoPath", dr["PhotoPath"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("Index","SEC_User");
                }
                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("UserPassword") != null)
                {
                    return RedirectToAction("Index", "LOC_Country" , new { Area = "LOC_Country" });
                }
            }
            return View("SEC_UserList");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
