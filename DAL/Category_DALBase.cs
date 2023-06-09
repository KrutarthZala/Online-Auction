using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using OnlineAuction.BAL;
using System.Data.Common;
using System.Data;

namespace OnlineAuction.DAL
{
    public class Category_DALBase : DALHelper
    {
        #region dbo.PR_MST_Category_SelectAll

        public DataTable dbo_PR_MST_Category_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Category_SelectAll");

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

        #region dbo.PR_MST_Category_DeleteByPK

        public bool? dbo_PR_MST_Category_DeleteByPK(int? CategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Category_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, CategoryID);
                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_MST_Category_SelectByPK

        public DataTable dbo_PR_MST_Category_SelectByPK(int? CategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Category_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, CategoryID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;

            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
        }

        #endregion

        #region dbo.PR_MST_Category_Insert

        public DataTable dbo_PR_MST_Category_Insert(string CategoryName, string CategoryImage, string CategoryDetails)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Category_Insert");
                sqlDB.AddInParameter(dbCMD, "CategoryName", SqlDbType.NVarChar, CategoryName);
                sqlDB.AddInParameter(dbCMD, "CategoryImage", SqlDbType.NVarChar, CategoryImage);
                sqlDB.AddInParameter(dbCMD, "CategoryDetails", SqlDbType.NVarChar, CategoryDetails);
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

        #region dbo.PR_MST_Category_UpdateByPK

        public DataTable dbo_PR_MST_Category_UpdateByPK(int? CategoryID, string CategoryName, string? CategoryImage, string CategoryDetails)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Category_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, CategoryID);
                sqlDB.AddInParameter(dbCMD, "CategoryName", SqlDbType.NVarChar, CategoryName);
                sqlDB.AddInParameter(dbCMD, "CategoryImage", SqlDbType.NVarChar, CategoryImage);
                sqlDB.AddInParameter(dbCMD, "CategoryDetails", SqlDbType.NVarChar, CategoryDetails);
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
