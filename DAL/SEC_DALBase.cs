using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;

namespace OnlineAuction.DAL
{
    public class SEC_DALBase : DALHelper
    {
        
        #region dbo_PR_SEC_User_SelectByUserNameAndPassword
        public DataTable dbo_PR_SEC_User_SelectByUserNamePassword( string UserName,string UserPassword)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectByUserNameAndPassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "UserPassword", SqlDbType.NVarChar, UserPassword);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        

    }
}
