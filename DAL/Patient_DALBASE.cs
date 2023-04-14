using HealthCare.Areas.Devices.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using HealthCare.Areas.US_Patient.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace HealthCare.DAL
{
	public class Patient_DALBASE: DAL_Helper
	{
		#region patient selectall
		public DataTable PR_Patient_SelectAll()
		{

			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_SelectAll");
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

		#region patient Insert
		public DataTable PR_Patient_Insert(PatientModel pt)
		{
			try
            {                
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_Insert");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "patientName", SqlDbType.NVarChar, pt.PatientName);
                sqlDB.AddInParameter(dbCMD, "birthDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "gender", SqlDbType.NVarChar, pt.Gender);
                sqlDB.AddInParameter(dbCMD, "email", SqlDbType.NVarChar, pt.Email);
                sqlDB.AddInParameter(dbCMD, "phone", SqlDbType.NVarChar, pt.PhoneNumber);
                sqlDB.AddInParameter(dbCMD, "add", SqlDbType.NVarChar, pt.address);
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

		#region Method: patient_delete
		public bool? PR_Patient_Delete(int? PatientID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_DeleteByPK");
				sqlDB.AddInParameter(dbCMD, "patientID", SqlDbType.Int, PatientID);
				int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
				return (vReturnValue == -1 ? false : true);
			}
			catch (Exception e)
			{
				return null;
			}
		}

		#endregion

		#region Method: PR_Patient_SelectByPk
		public DataTable PR_Patient_SelectByPK(int? PatientID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_SelectByPK");
				sqlDB.AddInParameter(dbCMD, "patientID", SqlDbType.Int, PatientID);
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

		#region Metho: PR_Patient_Update
		public DataTable PR_Patient_Update(PatientModel pt)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Patient_UpdateByPK");
				DataTable dt = new DataTable();
				sqlDB.AddInParameter(dbCMD, "patientID", SqlDbType.Int, pt.PatientID);
				sqlDB.AddInParameter(dbCMD, "patientName", SqlDbType.NVarChar, pt.PatientName);
                sqlDB.AddInParameter(dbCMD, "birthDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "gender", SqlDbType.NVarChar, pt.Gender);
				sqlDB.AddInParameter(dbCMD, "@email", SqlDbType.NVarChar, pt.Email);
				sqlDB.AddInParameter(dbCMD, "@phone", SqlDbType.NVarChar, pt.PhoneNumber);
				sqlDB.AddInParameter(dbCMD, "@add", SqlDbType.NVarChar, pt.address);
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
