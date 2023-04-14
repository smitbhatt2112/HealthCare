using HealthCare.areas.US_Doctor.Models;
using HealthCare.BAL;
using HealthCare.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HealthCare.areas.US_Doctor.Controllers
{
    [CheckAccess]
    [Area("US_Doctor")]
    [Route("US_Doctor/[controller]/[action]")]

    public class US_DoctorController : Controller
    {
        #region index
        public IActionResult Index()
        {
            Doctor_DALBASE dalLOC = new Doctor_DALBASE();
            DataTable dt = dalLOC.PR_Doctor_SelectAll();
            return View("DoctorList", dt);
           
        }
        #endregion

        #region Add
        public IActionResult Add(int? DoctorID)
        {
            Doctor_DALBASE Ddal= new Doctor_DALBASE();
            if (DoctorID!= null)
            {
                 DataTable dt = Ddal.PR_Doctor_SelectByPK(DoctorID);
                 if(dt.Rows.Count>0)
                 {
                    DoctorModel doct = new DoctorModel();
                    foreach(DataRow dr in dt.Rows)
                    {
                        doct.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                        doct.DoctorName = dr["DoctorName"].ToString();
                        doct.Description= dr["Description"].ToString();
                        doct.Email = dr["Email"].ToString();
                        doct.PhoneNumber = dr["PhoneNumber"].ToString();
                        doct.OfficeAddress = dr["OfficeAddress"].ToString();
                    }
                    return View("DoctorAddEdit",doct);
                 }
            }
            return View("DoctorAddEdit");

        }
        #endregion

        #region Save
        public IActionResult Save(DoctorModel doct)
        {
            Doctor_DALBASE ddal = new Doctor_DALBASE();
            if(doct.DoctorID == null)
            {
                if (Convert.ToBoolean(ddal.PR_LOC_Doctor_Insert(doct)))
                {
                    TempData["AlertMsg"] = "Record Inserted Succesfully";
                }
                
            }
            else
            {
                if (Convert.ToBoolean(ddal.PR_LOC_Doctor_Update(doct)))
                {
                    TempData["AlertMsg"] = "Record Updated Succesfully";
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int DoctorID)
        {
            Doctor_DALBASE ddal = new Doctor_DALBASE();
            
            if(Convert.ToBoolean(ddal.PR_LOC_Doctor_Delete(DoctorID)))
            {
                TempData["AlertMsg"] = "Record Deleted Successfully";
            }
            return RedirectToAction("Index");
        }
        #endregion
    }

}
