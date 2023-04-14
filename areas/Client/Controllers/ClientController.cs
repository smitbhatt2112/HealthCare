using HealthCare.Areas.Diseases.Models;
using HealthCare.BAL;
using HealthCare.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace HealthCare.Areas.Client.Controllers
{
    [CheckAccess]
    [Area("Client")]
    [Route("Client/[controller]/[action]")]

    public class ClientController : Controller
    {
        public IActionResult Index()
        {    
            return View("Homepage");
        }

        public IActionResult Disease()
        {
            Disease_DALBASE didal = new Disease_DALBASE();
            DataTable dt = didal.PR_Disease_SelectAll();            
            return View("Disease", dt);
        }

        public IActionResult Device(int? DiseaseID)
        {
            Disease_Device_DALBASE didal = new Disease_Device_DALBASE();
            DataTable dt = didal.PR_diseaseDevice_SelectByDiseaseID(DiseaseID);
            return View("Device", dt);
        }
        public IActionResult Doctor(int? DiseaseID)
        {
            SelectDisease_DALBASE didal = new SelectDisease_DALBASE();
            DataTable dt = didal.PR_Select_SelectByDiseaseID(DiseaseID);
            return View("Doctor", dt);
        }

        public IActionResult PatientInsert(int? DiseaseID, int? DoctorID)
        {
            Disease_DALBASE didal = new Disease_DALBASE();
            if (Convert.ToBoolean(didal.Disease_doctor_user_check(DiseaseID, DoctorID, Convert.ToInt32(HttpContext.Session.GetString("UserID")))))
            {
                TempData["insertalert"] = "You have alredy assigned with";
                return RedirectToAction("PatientView");
            }
            didal.PR_Disease_Doctor_user_Insert(DiseaseID,DoctorID, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return RedirectToAction("PatientView");
        }

        public IActionResult PatientView()
        {
            Disease_DALBASE didal = new Disease_DALBASE();
            DataTable dt = didal.PR_Disease_Doctor_UserSelectbyuserid(Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return View("Patient", dt);
        }

        public IActionResult DeleteHealthcare(int? AssignID)
        {
            Disease_DALBASE didal = new Disease_DALBASE();
            
            if (Convert.ToBoolean(didal.PR_Disease_Doctor_user_Delete(AssignID)))
            {
                TempData["AlertMsg"] = "Record Deleted Successfully";
            }
            return RedirectToAction("PatientView");
        }

    }
}
