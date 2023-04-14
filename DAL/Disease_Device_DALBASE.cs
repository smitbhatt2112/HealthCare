using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using HealthCare.Areas.SelectDisease.Models;
using HealthCare.Areas.DiseaseDevice.Models;

namespace HealthCare.DAL
{
    public class Disease_Device_DALBASE : DAL_Helper
    {
        #region Disease_device selectall
        public DataTable PR_DiseaseDevice_SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Device_SelectAll");
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

        #region disease_device Insert
        public DataTable PR_diseaseDevice_Insert(DiseaseDeviceModel dd)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Device_Insert");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "deviceID", SqlDbType.Int, dd.DeviceID);
                sqlDB.AddInParameter(dbCMD, "diseaseID", SqlDbType.Int, dd.DiseaseID);
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

        #region Metho: PR_DiseaseDevice_Update
        public DataTable PR_DiseaseDevice_Update(DiseaseDeviceModel sel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Device_UpdateByPK");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "assignID", SqlDbType.Int, sel.AssignID);
                sqlDB.AddInParameter(dbCMD, "DiseaseID", SqlDbType.Int, sel.DiseaseID);
                sqlDB.AddInParameter(dbCMD, "deviceID", SqlDbType.Int, sel.DeviceID);
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

        #region Method: PR_diseaseDevice_Delete
        public bool? PR_diseaseDevice_Delete(int? AssignID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Device_Delete");
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

        #region Method: PR_diseaseDevice_SelectByPk
        public DataTable PR_diseaseDevice_SelectByPK(int? AssignID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Device_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "assignID", SqlDbType.Int, AssignID);
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

        #region PR_Disease_SelectByDropDown
        public DataTable PR_Disease_SelectByDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_SelectComboBox");
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

        #region PR_Device_SelectByDropDown
        public DataTable PR_Device_SelectByDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Device_SelectComboBox");
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

        #region Method: PR_diseaseDevice_SelectByDiseaseID
        public DataTable PR_diseaseDevice_SelectByDiseaseID(int? DiseaseID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Device_SelectByDiseaseID");
                sqlDB.AddInParameter(dbCMD, "DiseaseID", SqlDbType.Int, DiseaseID);
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
