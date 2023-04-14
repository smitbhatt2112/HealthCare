using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using HealthCare.Models;

namespace HealthCare.Dal
{
    public class Master_DalBase
    {
        #region Method: PR_User_Select

        public DataTable User_Select(string conn, int UserID)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MLT_User_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

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


        #region Method: PR_User_SelectByPK
        public DataTable dbo_PR_User_Master_SelectByPK(string ConnStr, int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MLT_User_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

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

        #region Metho: PR_USer_Update
        public bool? PR_MLT_User_Update(string conn, User_MasterModel modelMLT_User, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MLT_User_Update");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, modelMLT_User.UserID);
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelMLT_User.UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, modelMLT_User.Password);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region dbo_PR_User_Master_SelectByUserNamePassword

        public DataTable dbo_PR_User_Master_SelectByUserNamePassword(string conn, string UserName, string Password)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MLT_User_SelectByUserNamePassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, Password);
                
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


        #region Method: PR_User_Insert
        public bool? PR_MLT_User_Insert(string conn, User_MasterModel modelUser_Master,int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MLT_User_Insert");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelUser_Master.UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, modelUser_Master.Password);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion






    }
}
