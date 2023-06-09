using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using OnlineAuction.BAL;

namespace OnlineAuction.DAL
{
    public class Product_DALBase : DALHelper
    {

        #region dbo.PR_PRO_Product_SelectAll
        public DataTable dbo_PR_PRO_Product_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRO_Product_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_PRO_Product_DeleteByPK

        public bool? dbo_PR_PRO_Product_DeleteByPK(int? ProductID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRO_Product_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, ProductID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_PRO_Product_SelectByPK

        public DataTable dbo_PR_PRO_Product_SelectByPK(int? ProductID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRO_Product_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, ProductID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());


                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_PRO_Product_Insert

        public DataTable dbo_PR_PRO_Product_Insert(string ProductName, string ProductImage, string ProductDetails,decimal? ProductPrice, string ProductStatus, int? CategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRO_Product_Insert");
                sqlDB.AddInParameter(dbCMD, "ProductName", SqlDbType.NVarChar, ProductName);
                sqlDB.AddInParameter(dbCMD, "ProductImage", SqlDbType.NVarChar, ProductImage);
                sqlDB.AddInParameter(dbCMD, "ProductDetails", SqlDbType.NVarChar, ProductDetails);
                sqlDB.AddInParameter(dbCMD, "ProductPrice", SqlDbType.Decimal, ProductPrice);
                sqlDB.AddInParameter(dbCMD, "ProductStatus", SqlDbType.NVarChar, ProductStatus);
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, CategoryID);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DBNull.Value);


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_PRO_Product_UpdateByPK

        public DataTable dbo_PR_PRO_Product_UpdateByPK(int? ProductID,string ProductName, string ProductImage, string ProductDetails, decimal? ProductPrice, string ProductStatus, int? CategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRO_Product_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, ProductID);
                sqlDB.AddInParameter(dbCMD, "ProductName", SqlDbType.NVarChar, ProductName);
                sqlDB.AddInParameter(dbCMD, "ProductImage", SqlDbType.NVarChar, ProductImage);
                sqlDB.AddInParameter(dbCMD, "ProductDetails", SqlDbType.NVarChar, ProductDetails);
                sqlDB.AddInParameter(dbCMD, "ProductPrice", SqlDbType.Decimal, ProductPrice);
                sqlDB.AddInParameter(dbCMD, "ProductStatus", SqlDbType.NVarChar, ProductStatus);
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, CategoryID);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DBNull.Value);


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}
