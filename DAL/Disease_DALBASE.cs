using HealthCare.areas.US_Doctor.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using HealthCare.Areas.Diseases.Models;
using System.Net;

namespace HealthCare.DAL
{
    public class Disease_DALBASE : DAL_Helper
    {
        #region Disease selectall
        public DataTable PR_Disease_SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_SelectAll");
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

        #region Disease Insert
        public bool? PR_Disease_Insert(DiseaseModel dis)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Insert");
                sqlDB.AddInParameter(dbCMD, "DiseaseName", SqlDbType.NVarChar, dis.DiseaseName);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_Disease_Delete
        public bool? PR_Disease_Delete(int? DiseaseID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "diseaseID", SqlDbType.Int, DiseaseID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region Method: PR_Disease_SelectByPk
        public DataTable PR_Disease_SelectByPK(int? DiseaseID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "diseaseID", SqlDbType.Int, DiseaseID);
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

        #region Metho: PR_Disease_Update
        public bool? PR_Diisease_Update(DiseaseModel dis)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "DiseaseID", SqlDbType.Int, dis.DiseaseID);
                sqlDB.AddInParameter(dbCMD, "DiseaseName", SqlDbType.NVarChar, dis.DiseaseName);           
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Disease_doctor_user Insert
        public DataTable PR_Disease_Doctor_user_Insert(int? DiseaseID, int? DoctorID , int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Docror_User_Insert");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "DiseaseID", SqlDbType.Int, DiseaseID);
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int,DoctorID);
                sqlDB.AddInParameter(dbCMD, "userID", SqlDbType.Int, UserID);
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

        #region Disease_doctor_user selectall
        public DataTable PR_Disease_Doctor_UserSelectbyuserid(int? UserID)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Doctor_User_SelectAllBYuserid");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "userID", SqlDbType.Int, UserID);
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



        #region Method: PR_Disease_Doctor_user_Delete
        public bool? PR_Disease_Doctor_user_Delete(int? AssignID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Doctor_user_Delete");
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

        #region Disease_doctor_user check
        public bool? Disease_doctor_user_check(int? DiseaseID, int? DoctorID, int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Disease_Doctor_User_SelectAllBYuser_doctor_disease_id");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "diseaseID", SqlDbType.Int, DiseaseID);
                sqlDB.AddInParameter(dbCMD, "doctorID", SqlDbType.Int, DoctorID);
                sqlDB.AddInParameter(dbCMD, "userID", SqlDbType.Int, UserID);
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                if(dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


    }
}

