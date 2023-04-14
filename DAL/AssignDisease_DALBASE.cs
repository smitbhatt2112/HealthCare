using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using HealthCare.Areas.Devices.Models;
using HealthCare.Areas.AssignDisease.Models;

namespace HealthCare.DAL
{
    public class AssignDisease_DALBASE: DAL_Helper
    {
        #region assignDisease selectall
        public DataTable PR_Disease_SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_AssignDisease_SelectAll");
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

        #region asssigndisease Insert
        public DataTable PR_assigndisease_Insert(AssignModel assi)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_assignDisease_Insert");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "DiseaseID", SqlDbType.Int, assi.DiseaseID);
                sqlDB.AddInParameter(dbCMD, "patientID", SqlDbType.Int, assi.PatientID);
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

        #region Metho: PR_assignDisease_Update
        public DataTable PR_Device_Update(AssignModel assi)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_assignDisease_UpdateByPK");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "assignID", SqlDbType.Int, assi.AssignID);
                sqlDB.AddInParameter(dbCMD, "DiseaseID", SqlDbType.Int, assi.DiseaseID);
                sqlDB.AddInParameter(dbCMD, "patientID", SqlDbType.Int, assi.PatientID);
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

        #region Method: PR_assigndisease_Delete
        public bool? PR_assigndisease_Delete(int? AssignID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_assignDisease_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "assignID", SqlDbType.Int, AssignID);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion


        #region Method: PR_assigndisease_SelectByPk
        public DataTable PR_assigndisease_SelectByPK(int? AssignID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_assignDisease_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "@assignID", SqlDbType.Int, AssignID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
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
