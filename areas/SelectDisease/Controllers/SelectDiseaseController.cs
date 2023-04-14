using HealthCare.areas.US_Doctor.Models;
using HealthCare.Areas.Devices.Models;
using HealthCare.Areas.Diseases.Models;
using HealthCare.Areas.SelectDisease.Models;
using HealthCare.BAL;
using HealthCare.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;

namespace HealthCare.Areas.SelectDisease.Controllers
{
    [CheckAccess]
    [Area("SelectDisease")]
    [Route("SelectDisease/[controller]/[action]")]
    public class SelectDiseaseController : Controller
    {
        #region Index
        public IActionResult Index()
        {
            SelectDisease_DALBASE ds = new SelectDisease_DALBASE();
            DataTable dt = ds.PR_SelectDisease_SelectAll();
            return View("SelectDiseaseList", dt);
        }
        #endregion

        #region Add
        public IActionResult Add(int? SelectID)
        {
            SelectDisease_DALBASE Ddal = new SelectDisease_DALBASE();

            #region ComboBOX Disease                     
            DataTable dt1 = Ddal.PR_Disease_SelectByDropDown();

            List<DiseaseDropDownModel> list1 = new List<DiseaseDropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                DiseaseDropDownModel vlst = new DiseaseDropDownModel();
                vlst.DiseaseID = Convert.ToInt32(dr["diseaseID"]);
                vlst.DiseaseName = dr["diseaseName"].ToString();
                list1.Add(vlst);
            }
            ViewBag.DiseaseList = list1;
            #endregion

            #region ComboBOX Doctor

            DataTable dt2 = Ddal.PR_Doctor_SelectByDropDown();

            List<DoctorDropDownModel> list2 = new List<DoctorDropDownModel>();
            foreach (DataRow dr in dt2.Rows)
            {
                DoctorDropDownModel vlst = new DoctorDropDownModel();
                vlst.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                vlst.DoctorName = dr["DoctorName"].ToString();
                list2.Add(vlst);
            }
            ViewBag.DoctorList = list2;

            #endregion 


            if (SelectID != null)
            {
                DataTable dt = Ddal.PR_Selectdisease_SelectByPK(SelectID);
                if (dt.Rows.Count > 0)
                {
                    SelectDiseaseModel de = new SelectDiseaseModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        de.SelectID = Convert.ToInt32(dr["SelectID"]);
                        de.DiseaseID = Convert.ToInt32(dr["DiseaseID"]);
                        de.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                    }
                    return View("SelectDiseaseAddEdit", de);
                }
            }
            return View("SelectDiseaseAddEdit");

        }
        #endregion

        #region Save
        public IActionResult Save(SelectDiseaseModel sd)
        {
            SelectDisease_DALBASE ddal = new SelectDisease_DALBASE();
            if (sd.SelectID == null)
            {
                DataTable dt = ddal.PR_Selectdisease_Insert(sd);
                TempData["AlertMsg"] = "Record Inserted Succesfully";

            }
            else
            {
                DataTable dt = ddal.PR_SelectDisease_Update(sd);
                TempData["AlertMsg"] = "Record Updated Succesfully";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int SelectId)
        {
            SelectDisease_DALBASE ddal = new SelectDisease_DALBASE();

            if (Convert.ToBoolean(ddal.PR_Selectdisease_Delete(SelectId)))
            {
                TempData["AlertMsg"] = "Record Deleted Successfully";
            }
            return RedirectToAction("Index");
        }
        #endregion



    }
}
