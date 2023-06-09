using Microsoft.AspNetCore.Mvc;
using OnlineAuction.Areas.LOC_Country.Models;
using OnlineAuction.Areas.MST_Category.Models;
using OnlineAuction.Areas.PRO_Product.Models;
using OnlineAuction.Areas.PRO_Product.Models;
using OnlineAuction.BAL;
using OnlineAuction.DAL;
using System.Data;
using System.Data.SqlClient;

namespace OnlineAuction.Areas.PRO_Product.Controllers
{
    [CheckAccess]
    [Area("PRO_Product")]
    [Route("PRO_Product/[controller]/[action]")]
    public class PRO_ProductController : Controller
    {

        Product_DAL dalProduct = new Product_DAL();

        private IConfiguration Configuration;
        public PRO_ProductController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalProduct.dbo_PR_PRO_Product_SelectAll();
            return View("PRO_ProductList",dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int ProductID)
        {
            dalProduct.dbo_PR_PRO_Product_DeleteByPK(ProductID);

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
        public IActionResult Add(int? ProductID)
        {
            #region CategoryDropdown
            //Establish connection using ConnectionStrings
            string str = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            //SQL Command to retrieve State List 
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MST_Category_SelectForDropDown";

            DataTable dtProduct = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dtProduct.Load(sdr);
            conn.Close();

            List<MST_Category_DropDownModel> list = new List<MST_Category_DropDownModel>();
            foreach (DataRow dr in dtProduct.Rows)
            {
                MST_Category_DropDownModel vlist = new MST_Category_DropDownModel();
                vlist.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                vlist.CategoryName = dr["CategoryName"].ToString();
                list.Add(vlist);
            }
            ViewBag.CategoryList = list;
            #endregion

            #region SelectByPK

            if (ProductID != null)
            {

                DataTable dt = dalProduct.dbo_PR_PRO_Product_SelectByPK(ProductID);

                PRO_ProductModel modelPRO_Product= new PRO_ProductModel();

                foreach (DataRow dr in dt.Rows)
                {

                    modelPRO_Product.ProductID = Convert.ToInt32(dr["ProductID"]);
                    modelPRO_Product.ProductName = dr["ProductName"].ToString();
                    modelPRO_Product.ProductImage = dr["ProductImage"].ToString();
                    modelPRO_Product.ProductDetails = dr["ProductDetails"].ToString();
                    modelPRO_Product.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
                    modelPRO_Product.ProductStatus = dr["ProductStatus"].ToString();
                    modelPRO_Product.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    modelPRO_Product.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelPRO_Product.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("PRO_ProductAddEdit", modelPRO_Product);
            }

            return View("PRO_ProductAddEdit");

            #endregion
        }
        #endregion

        #region Method : Save

        [HttpPost]
        public IActionResult Save(PRO_ProductModel modelPRO_Product)
        {
            if (modelPRO_Product.File != null)
            {
                string FilePath = "wwwroot\\UploadProduct";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileNameWithPath = Path.Combine(path, modelPRO_Product.File.FileName);
                modelPRO_Product.ProductImage = FilePath.Replace("wwwroot\\", "/") + "/" + modelPRO_Product.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelPRO_Product.File.CopyTo(stream);
                }
            }

            if (modelPRO_Product.ProductID == null)
            {

                DataTable dt = dalProduct.dbo_PR_PRO_Product_Insert(modelPRO_Product.ProductName, modelPRO_Product.ProductImage, modelPRO_Product.ProductDetails, modelPRO_Product.ProductPrice,modelPRO_Product.ProductStatus,modelPRO_Product.ProductID);

                TempData["ProductInsertMsg"] = "Product Inserted Succesfully";
            }
            else
            {

                DataTable dt = dalProduct.dbo_PR_PRO_Product_UpdateByPK(modelPRO_Product.ProductID, modelPRO_Product.ProductName, modelPRO_Product.ProductImage, modelPRO_Product.ProductDetails, modelPRO_Product.ProductPrice, modelPRO_Product.ProductStatus, modelPRO_Product.ProductID);

                TempData["ProductInsertMsg"] = "Product Updated Succesfully";

                return View("PRO_ProductAddEdit");
            }

            return View("PRO_ProductAddEdit");

        }

        #endregion
    }
}
