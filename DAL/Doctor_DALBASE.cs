using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using HealthCare.areas.US_Doctor.Models;

namespace HealthCare.DAL
{
    public class Doctor_DALBASE : DAL_Helper
    {
        #region US_Doctor selectall
        public DataTable PR_Doctor_SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_SelectAll");
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

        #region USDoctor Insert
        public bool? PR_LOC_Doctor_Insert(DoctorModel model_DOC)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_Insert");
                sqlDB.AddInParameter(dbCMD, "doctorName", SqlDbType.NVarChar, model_DOC.DoctorName);
                sqlDB.AddInParameter(dbCMD, "des", SqlDbType.NVarChar, model_DOC.Description);
                sqlDB.AddInParameter(dbCMD, "email", SqlDbType.NVarChar, model_DOC.Email);
                sqlDB.AddInParameter(dbCMD, "phone", SqlDbType.NVarChar, model_DOC.PhoneNumber);
                sqlDB.AddInParameter(dbCMD, "officeAdd", SqlDbType.NVarChar, model_DOC.OfficeAddress);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_Doctor_Delete
        public bool? PR_LOC_Doctor_Delete(int? DoctorID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "doctorID", SqlDbType.Int, DoctorID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region Method: PR_Doctor_SelectByPk
        public DataTable PR_Doctor_SelectByPK(int? DoctorID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "doctorID", SqlDbType.Int, DoctorID);
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

        #region Metho: PR_Doctor_Update
        public bool? PR_LOC_Doctor_Update( DoctorModel model_DOC)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "doctorID", SqlDbType.Int, model_DOC.DoctorID);
                sqlDB.AddInParameter(dbCMD, "doctorName", SqlDbType.NVarChar, model_DOC.DoctorName);
                sqlDB.AddInParameter(dbCMD, "des", SqlDbType.NVarChar, model_DOC.Description);
                sqlDB.AddInParameter(dbCMD, "email", SqlDbType.NVarChar, model_DOC.Email);
                sqlDB.AddInParameter(dbCMD, "phone", SqlDbType.NVarChar, model_DOC.PhoneNumber);
                sqlDB.AddInParameter(dbCMD, "officeAdd", SqlDbType.NVarChar, model_DOC.OfficeAddress);
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
