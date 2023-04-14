using HealthCare.areas.US_Doctor.Models;
using HealthCare.Areas.US_Patient.Models;
using HealthCare.BAL;
using HealthCare.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;

namespace HealthCare.Areas.US_Patient.Controllers
{
    [CheckAccess]
    [Area("US_Patient")]
    [Route("US_Patient/[controller]/[action]")]
    public class US_PatientController : Controller
	{
        #region Inex
        public IActionResult Index()
		{
			Patient_DALBASE pt = new Patient_DALBASE();
			DataTable dt = pt.PR_Patient_SelectAll();
			return View("PatientList", dt);
		}
        #endregion


        #region Add
        public IActionResult Add(int? PatientID)
        {
            #region ComboBOX gender
           
            List<string> list = new List<string>();
            
                list.Add("Male");
                list.Add("Female");
            ViewBag.GenderList = list;

            #endregion 

            Patient_DALBASE ptd = new Patient_DALBASE();
            if (PatientID != null)
            {
                DataTable dt = ptd.PR_Patient_SelectByPK(PatientID);                  
                if (dt.Rows.Count > 0)
                {
                    PatientModel ptm = new PatientModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ptm.PatientID = Convert.ToInt32(dr["[Patient_ID]"]);
                        ptm.PatientName = dr["PatientName"].ToString();
                        ptm.Birthdate = Convert.ToDateTime(dr["BirthDate"]);
                        ptm.Gender = dr["Gender"].ToString();
                        ptm.Email = dr["Email"].ToString();
                        ptm.PhoneNumber = dr["PhoneNumber"].ToString();
                        ptm.address = dr["address"].ToString();
                    }
                    return View("PatientAddEdit", ptm);
                }
            }
            return View("PatientAddEdit");

        }
        #endregion

        #region Save
        public IActionResult Save(PatientModel pt)
        {
            Patient_DALBASE ddal = new Patient_DALBASE();
            if (pt.PatientID == null)
            {
                DataTable dt = ddal.PR_Patient_Insert(pt);
                TempData["AlertMsg"] = "Record Inserted Succesfully";

            }
            else
            {

                DataTable dt = ddal.PR_Patient_Update(pt);
                TempData["AlertMsg"] = "Record Updated Succesfully";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int PatientID)
        {
            Patient_DALBASE ddal = new Patient_DALBASE();
            if (Convert.ToBoolean(ddal.PR_Patient_Delete(PatientID)))
            {
                TempData["AlertMsg"] = "Record Deleted Successfully";
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
