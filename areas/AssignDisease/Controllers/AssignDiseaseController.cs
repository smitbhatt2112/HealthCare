using HealthCare.Areas.AssignDisease.Models;
using HealthCare.Areas.Devices.Models;
using HealthCare.BAL;
using HealthCare.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HealthCare.Areas.AssignDisease.Controllers
{
    public class AssignDiseaseController : Controller
    {
        [CheckAccess]
        [Area("AssignDisease")]
        [Route("AssignDisease/[controller]/[action]")]

        #region Index
        public IActionResult Index()
        {

            AssignDisease_DALBASE ds = new AssignDisease_DALBASE();
            DataTable dt = ds.PR_Disease_SelectAll();
            return View("AssignList", dt);
        }
        #endregion


        #region Add
        public IActionResult Add(int? AssignID)
        {
            AssignDisease_DALBASE Ddal = new AssignDisease_DALBASE();
            if (AssignID != null)
            {
                DataTable dt = Ddal.PR_assigndisease_SelectByPK(AssignID);
                if (dt.Rows.Count > 0)
                {
                    AssignModel de = new AssignModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        de.AssignID = Convert.ToInt32(dr["AssignID"]);
                        de.DiseaseID = Convert.ToInt32(dr["DiseaseID"]);
                        de.AssignID = Convert.ToInt32(dr["PatientID"]);
                    }
                    return View("AssignAddEdit", de);
                }
            }
            return View("AssignAddEdit");

        }
        #endregion

    }
}
