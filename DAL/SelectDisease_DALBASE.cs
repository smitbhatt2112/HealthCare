using HealthCare.Areas.AssignDisease.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using HealthCare.Areas.SelectDisease.Models;

namespace HealthCare.DAL
{
    public class SelectDisease_DALBASE : DAL_Helper
    {
        #region selectDisease selectall
        public DataTable PR_SelectDisease_SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectDisease_SelectAll");
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

        #region selectdisease Insert
        public DataTable PR_Selectdisease_Insert(SelectDiseaseModel assi)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectDisease_Insert");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "DiseaseID", SqlDbType.Int, assi.DiseaseID);
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int, assi.DoctorID);
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

        #region Metho: PR_selectDisease_Update
        public DataTable PR_SelectDisease_Update(SelectDiseaseModel sel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectDisease_UpdateByPK");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "selectID", SqlDbType.Int, sel.SelectID);
                sqlDB.AddInParameter(dbCMD, "DiseaseID", SqlDbType.Int, sel.DiseaseID);
                sqlDB.AddInParameter(dbCMD, "DoctorID", SqlDbType.Int, sel.DoctorID);
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

        #region Method: PR_selectdisease_Delete
        public bool? PR_Selectdisease_Delete(int? SelectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_selectDisease_Delete");
                sqlDB.AddInParameter(dbCMD, "SelectID", SqlDbType.Int, SelectID);
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
        public DataTable PR_Selectdisease_SelectByPK(int? SelectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectDisease_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "SelectID", SqlDbType.Int, SelectID);
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

        #region PR_Doctor_SelectByDropDown
        public DataTable PR_Doctor_SelectByDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Doctor_SelectComboBox");
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

        #region PR_Doctor_SelectByDisease
        public DataTable PR_Select_SelectByDiseaseID(int? DiseaseID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectDisease_ByDiseasePK");
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
