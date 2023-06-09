using AddressBook.DAL;
using Microsoft.AspNetCore.Mvc;
using OnlineAuction.Areas.LOC_Country.Models;
using OnlineAuction.Areas.LOC_State.Models;
using OnlineAuction.BAL;
using System.Data;
using System.Data.SqlClient;

namespace OnlineAuction.Areas.LOC_State.Controllers
{
    [CheckAccess]
    [Area("LOC_State")]
    [Route("LOC_State/[controller]/[action]")]
    public class LOC_StateController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        private IConfiguration Configuration;
        public LOC_StateController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region SelectAll
        public IActionResult Index()
        {
            #region CountryDropDown

            //Establish connection using ConnectionStrings
            string str = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            //SQL Command to retrieve State List 
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_Country_SelectForDropDown";
            cmd.Parameters.Add("UserID", SqlDbType.Int).Value = CV.UserID();

            DataTable dtCountry = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dtCountry.Load(sdr);
            conn.Close();

            List<LOC_CountryDropDownModel> list = new List<LOC_CountryDropDownModel>();
            foreach (DataRow dr in dtCountry.Rows)
            {
                LOC_CountryDropDownModel vlist = new LOC_CountryDropDownModel();
                vlist.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlist.CountryName = dr["CountryName"].ToString();
                list.Add(vlist);
            }
            ViewBag.CountryList = list;
            #endregion

            DataTable dt = dalLOC.dbo_PR_LOC_State_SelectAll();

            return View("LOC_StateList", dt);

        }
        #endregion

        #region Delete
        public IActionResult Delete(int StateID)
        {
            dalLOC.dbo_PR_LOC_State_DeleteByPK(StateID);

            return RedirectToAction("Index");
        }
        #endregion

        #region Method : Add

        public IActionResult Add(int? StateID)
        {
            #region CountryDropdown
            //Establish connection using ConnectionStrings
            string str = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            //SQL Command to retrieve State List 
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_Country_SelectForDropDown";
            cmd.Parameters.Add("UserID", SqlDbType.Int).Value = CV.UserID();

            DataTable dtCountry = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dtCountry.Load(sdr);
            conn.Close();

            List<LOC_CountryDropDownModel> list = new List<LOC_CountryDropDownModel>();
            foreach (DataRow dr in dtCountry.Rows)
            {
                LOC_CountryDropDownModel vlist = new LOC_CountryDropDownModel();
                vlist.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlist.CountryName = dr["CountryName"].ToString();
                list.Add(vlist);
            }
            ViewBag.CountryList = list;
            #endregion

            #region SelectByPK
            if (StateID != null)
            {

                DataTable dt = dalLOC.dbo_PR_LOC_State_SelectByPK(StateID);

                LOC_StateModel modelLOC_State = new LOC_StateModel();

                foreach (DataRow dr in dt.Rows)
                {

                    modelLOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                    modelLOC_State.StateName = dr["StateName"].ToString();
                    modelLOC_State.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_State.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelLOC_State.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("LOC_StateAddEdit", modelLOC_State);
            }

            return View("LOC_StateAddEdit");
            #endregion

            
        }
        #endregion

        #region Method : Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region Method : Save

        [HttpPost]
        public IActionResult Save(LOC_StateModel modelLOC_State)
        {

            if (modelLOC_State.StateID == null)
            {

                DataTable dt = dalLOC.dbo_PR_LOC_State_Insert(modelLOC_State.StateName, modelLOC_State.CountryID);

                TempData["StateInsertMsg"] = "State Inserted Succesfully";
            }
            else
            {

                DataTable dt = dalLOC.dbo_PR_LOC_State_UpdateByPK(modelLOC_State.StateID, modelLOC_State.StateName, modelLOC_State.CountryID);

                TempData["CountryInsertMsg"] = "State Updated Succesfully";
                return View("LOC_StateAddEdit");
            }

            return View("LOC_StateAddEdit");

        }

        #endregion

        #region Method : Search
        public IActionResult Search(LOC_StateModel modelLOC_State)
        {

            #region Dropdown
            //Establish connection using ConnectionStrings
            string str = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            //SQL Command to retrieve State List 
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_Country_SelectForDropDown";
            cmd.Parameters.Add("UserID", SqlDbType.Int).Value = CV.UserID();

            DataTable dtCountry = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dtCountry.Load(sdr);
            conn.Close();

            List<LOC_CountryDropDownModel> list = new List<LOC_CountryDropDownModel>();
            foreach (DataRow dr in dtCountry.Rows)
            {
                LOC_CountryDropDownModel vlist = new LOC_CountryDropDownModel();
                vlist.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlist.CountryName = dr["CountryName"].ToString();
                list.Add(vlist);
            }
            ViewBag.CountryList = list;
            #endregion

            DataTable dt = dalLOC.dbo_PR_LOC_State_SelectByStateNameCountryID(modelLOC_State.StateName, modelLOC_State.CountryID);

            return View("LOC_StateList", dt);
        }
        #endregion
    }
}
