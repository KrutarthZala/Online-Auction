using Microsoft.AspNetCore.Mvc;
using OnlineAuction.Areas.LOC_Country.Models;
using OnlineAuction.Areas.MST_Category.Models;
using OnlineAuction.BAL;
using OnlineAuction.DAL;
using System.Data;

namespace OnlineAuction.Areas.MST_Category.Controllers
{
    [CheckAccess]
    [Area("MST_Category")]
    [Route("MST_Category/[controller]/[action]")]
    public class MST_CategoryController : Controller
    {
        Category_DAL dalCategory = new Category_DAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalCategory.dbo_PR_MST_Category_SelectAll();
            return View("MST_CategoryList",dt);
        }
        #endregion 

        #region Delete
        public IActionResult Delete(int CategoryID)
        {
            dalCategory.dbo_PR_MST_Category_DeleteByPK(CategoryID);

            return RedirectToAction("Index");
        }
        #endregion

        #region Method : Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region Method : Add
        public IActionResult Add(int? CategoryID)
        {

            if (CategoryID != null)
            {

                DataTable dt = dalCategory.dbo_PR_MST_Category_SelectByPK(CategoryID);

               MST_CategoryModel modelMST_Category = new MST_CategoryModel();

                foreach (DataRow dr in dt.Rows)
                {

                    modelMST_Category.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    modelMST_Category.CategoryName = dr["CategoryName"].ToString();
                    modelMST_Category.CategoryImage = dr["CategoryImage"].ToString();
                    modelMST_Category.CategoryDetails = dr["CategoryDetails"].ToString();
                    modelMST_Category.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelMST_Category.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("MST_CategoryAddEdit", modelMST_Category);
            }

            return View("MST_CategoryAddEdit");
        }
        #endregion

        #region Method : Save

        [HttpPost]
        public IActionResult Save(MST_CategoryModel modelMST_Category)
        {
            if (modelMST_Category.File != null)
            {
                string FilePath = "wwwroot\\UploadCategory";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileNameWithPath = Path.Combine(path, modelMST_Category.File.FileName);
                modelMST_Category.CategoryImage = FilePath.Replace("wwwroot\\", "/") + "/" + modelMST_Category.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelMST_Category.File.CopyTo(stream);
                }
            }

            if (modelMST_Category.CategoryID == null)
            {

                DataTable dt = dalCategory.dbo_PR_MST_Category_Insert(modelMST_Category.CategoryName, modelMST_Category.CategoryImage, modelMST_Category.CategoryDetails);

                TempData["CategoryInsertMsg"] = "Category Inserted Succesfully";
            }
            else
            {

                DataTable dt = dalCategory.dbo_PR_MST_Category_UpdateByPK(modelMST_Category.CategoryID, modelMST_Category.CategoryName, modelMST_Category.CategoryImage, modelMST_Category.CategoryDetails);

                TempData["CategoryInsertMsg"] = "Category Updated Succesfully";

                return View("MST_CategoryAddEdit");
            }

            return View("MST_CategoryAddEdit");

        }

        #endregion
    }
}
