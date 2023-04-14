using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using HealthCare.Areas.Devices.Models;


namespace HealthCare.DAL
{
    public class Device_DALBASE: DAL_Helper
    {
        #region device selectall
        public DataTable PR_Device_SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Devices_SelectAll");
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

        #region device Insert
        public DataTable PR_Device_Insert(DevicesModel device)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Device_Insert");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "DeviceName", SqlDbType.NVarChar, device.DeviceName);
                sqlDB.AddInParameter(dbCMD, "DeviceBarnd", SqlDbType.NVarChar, device.DeviceBrand);
                sqlDB.AddInParameter(dbCMD, "DevicePhotoPath", SqlDbType.NVarChar, device.PhotoPath);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.NVarChar, device.Price);
                sqlDB.AddInParameter(dbCMD, "des", SqlDbType.NVarChar, device.Description);;
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

        #region Method: PR_Device_Delete
        public bool? PR_Device_Delete(int? DeviceID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "DeviceID", SqlDbType.Int, DeviceID);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region Method: PR_Device_SelectByPk
        public DataTable PR_Device_SelectByPK(int? DeviceID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Devices_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "deviceID", SqlDbType.Int, DeviceID);
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

        #region Metho: PR_Device_Update
        public DataTable PR_Device_Update(DevicesModel dev)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Devices_UpdateByPK");
				DataTable dt = new DataTable();
				sqlDB.AddInParameter(dbCMD, "DeviceID", SqlDbType.Int, dev.DeviceID);
                sqlDB.AddInParameter(dbCMD, "DeviceName", SqlDbType.NVarChar, dev.DeviceName);
                sqlDB.AddInParameter(dbCMD, "DeviceBrand", SqlDbType.NVarChar, dev.DeviceBrand);
                sqlDB.AddInParameter(dbCMD, "DevicePhotoPath", SqlDbType.NVarChar, dev.PhotoPath);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.NVarChar, dev.Price);
                sqlDB.AddInParameter(dbCMD, "des", SqlDbType.NVarChar, dev.Description);
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

