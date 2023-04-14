
using HealthCare.Areas.Diseases.Models;
using HealthCare.BAL;
using HealthCare.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HealthCare.Areas.Diseases.Controllers
{
    [CheckAccess]
    [Area("Diseases")]
    [Route("Diseases/[controller]/[action]")]
    public class DiseasesController : Controller
    {
        #region Index
        public IActionResult Index()
        {
            Disease_DALBASE didal= new Disease_DALBASE();
            DataTable dt = didal.PR_Disease_SelectAll();
            return View("DiseaseList",dt);         
        }
        #endregion

        #region Add
        public IActionResult Add(int? DiseaseID)
        {
            Disease_DALBASE Ddal = new Disease_DALBASE();
            
            if (DiseaseID != null)
            {
                DataTable dt = Ddal.PR_Disease_SelectByPK(DiseaseID);

                if (dt.Rows.Count > 0)
                {
                    DiseaseModel dis = new DiseaseModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        
                        dis.DiseaseID = Convert.ToInt32(dr["DiseaseID"]);
                        dis.DiseaseName = dr["DiseaseName"].ToString();                       
                    }
                    return View("DiseaseAddEdit", dis);
                }
            }
            return View("DiseaseAddEdit");

        }
        #endregion

        #region Save
        public IActionResult Save(DiseaseModel dis)
        {
            Disease_DALBASE ddal = new Disease_DALBASE();
            if (dis.DiseaseID == null)
            {
                if (Convert.ToBoolean(ddal.PR_Disease_Insert(dis)))
                {
                    TempData["AlertMsg"] = "Record Inserted Succesfully";
                }

            }
            else
            {
                if (Convert.ToBoolean(ddal.PR_Diisease_Update(dis)))
                {
                    TempData["AlertMsg"] = "Record Updated Succesfully";
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int DiseaseID)
        {
            Disease_DALBASE ddal = new Disease_DALBASE();

            if (Convert.ToBoolean(ddal.PR_Disease_Delete(DiseaseID)))
            {
                TempData["AlertMsg"] = "Record Deleted Successfully";
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
