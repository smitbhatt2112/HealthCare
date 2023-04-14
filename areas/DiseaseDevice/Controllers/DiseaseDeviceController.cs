using HealthCare.Areas.Diseases.Models;
using HealthCare.Areas.SelectDisease.Models;
using HealthCare.areas.US_Doctor.Models;
using HealthCare.BAL;
using HealthCare.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using HealthCare.Areas.Devices.Models;
using HealthCare.Areas.DiseaseDevice.Models;

namespace HealthCare.Areas.DiseaseDevice.Controllers

{
        [CheckAccess]
        [Area("DiseaseDevice")]
        [Route("DiseaseDevice/[controller]/[action]")]
    public class DiseaseDeviceController : Controller
    {
        
        #region Index
        public IActionResult Index()
        {
            Disease_Device_DALBASE ds = new Disease_Device_DALBASE();
            DataTable dt = ds.PR_DiseaseDevice_SelectAll();
            return View("DiseaseDeviceList", dt);
        }
        #endregion

        #region Add
        public IActionResult Add(int? AssignID)
        {
            Disease_Device_DALBASE Ddal = new Disease_Device_DALBASE();

            #region ComboBOX Disease                     
            DataTable dt1 = Ddal.PR_Disease_SelectByDropDown();

            List<DiseaseDropDownModel> list1 = new List<DiseaseDropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                DiseaseDropDownModel vlst1 = new DiseaseDropDownModel();
                vlst1.DiseaseID = Convert.ToInt32(dr["diseaseID"]);
                vlst1.DiseaseName = dr["diseaseName"].ToString();
                list1.Add(vlst1);
            }
            ViewBag.DiseaseList = list1;
            #endregion

            #region ComboBOX Device

            DataTable dt2 = Ddal.PR_Device_SelectByDropDown();

            List<DeviceDropDownModel> list2 = new List<DeviceDropDownModel>();
            foreach (DataRow dr in dt2.Rows)
            {
                DeviceDropDownModel vlst2 = new DeviceDropDownModel();
                vlst2.DeviceID = Convert.ToInt32(dr["DeviceID"]);
                vlst2.DeviceName = dr["DeviceName"].ToString();
                list2.Add(vlst2);
            }
            ViewBag.DeviceList = list2;

            #endregion 


            if (AssignID != null)
            {
                DataTable dt = Ddal.PR_diseaseDevice_SelectByPK(AssignID);
                if (dt.Rows.Count > 0)
                {
                    DiseaseDeviceModel de = new DiseaseDeviceModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        de.AssignID = Convert.ToInt32(dr["AssignID"]);
                        de.DiseaseID = Convert.ToInt32(dr["DiseaseID"]);
                        de.DeviceID = Convert.ToInt32(dr["DeviceID"]);
                    }
                    return View("DiseaseDeviceAddEdit", de);
                }
            }
            return View("DiseaseDeviceAddEdit");

        }
        #endregion

        #region Save
        public IActionResult Save(DiseaseDeviceModel dd)
        {
            Disease_Device_DALBASE ddal = new Disease_Device_DALBASE();
            if (dd.AssignID == null)
            {
                DataTable dt = ddal.PR_diseaseDevice_Insert(dd);
                TempData["AlertMsg"] = "Record Inserted Succesfully";

            }
            else
            {
                DataTable dt = ddal.PR_DiseaseDevice_Update(dd);
                TempData["AlertMsg"] = "Record Updated Succesfully";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int AssignID)
        {
            Disease_Device_DALBASE ddal = new Disease_Device_DALBASE();

            if (Convert.ToBoolean(ddal.PR_diseaseDevice_Delete(AssignID)))
            {
                TempData["AlertMsg"] = "Record Deleted Successfully";
            }
            return RedirectToAction("Index");
        }
        #endregion


    }
}
