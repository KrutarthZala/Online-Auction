using AddressBook.DAL;
using Microsoft.AspNetCore.Mvc;
using OnlineAuction.Areas.LOC_Country.Models;
using OnlineAuction.BAL;
using System.Data;

namespace OnlineAuction.Areas.LOC_Country.Controllers
{
    [CheckAccess]
    [Area("LOC_Country")]
    [Route("LOC_Country/[controller]/[action]")]
    public class LOC_CountryController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        #region SelectAll
        public IActionResult Index()
        {

            DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectAll();
            return View("LOC_CountryList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CountryID)
        {
            dalLOC.dbo_PR_LOC_Country_DeleteByPK(CountryID);

            return RedirectToAction("Index");
        }
        #endregion

        #region Method : Add
        public IActionResult Add(int? CountryID)
        {

            if (CountryID != null)
            {

                DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectByPK(CountryID);

                LOC_CountryModel modelLOC_Country = new LOC_CountryModel();

                foreach (DataRow dr in dt.Rows)
                {

                    modelLOC_Country.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_Country.CountryName = dr["CountryName"].ToString();
                    modelLOC_Country.CountryCode = dr["CountryCode"].ToString();
                    modelLOC_Country.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelLOC_Country.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("LOC_CountryAddEdit", modelLOC_Country);
            }

            return View("LOC_CountryAddEdit");
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
        public IActionResult Save(LOC_CountryModel modelLOC_CountryModel)
        {          

            if (modelLOC_CountryModel.CountryID == null)
            {
                
                DataTable dt = dalLOC.dbo_PR_LOC_Country_Insert(modelLOC_CountryModel.CountryName, modelLOC_CountryModel.CountryCode);

                TempData["CountryInsertMsg"] = "Country Inserted Succesfully";
            }
            else
            {

                DataTable dt = dalLOC.dbo_PR_LOC_Country_UpdateByPK(modelLOC_CountryModel.CountryID, modelLOC_CountryModel.CountryName, modelLOC_CountryModel.CountryCode);

                TempData["CountryInsertMsg"] = "Country Updated Succesfully";
                return View("LOC_CountryAddEdit");
            }

            return View("LOC_CountryAddEdit");

        }
        #endregion

        #region Method : Search
        public IActionResult Search(LOC_CountryModel modelLOC_Country)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_Country_CountryNameCode(modelLOC_Country.CountryName, modelLOC_Country.CountryCode);

            return View("LOC_CountryList",dt );
        }
        #endregion

    }
}
