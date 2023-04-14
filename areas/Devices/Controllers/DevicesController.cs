using HealthCare.areas.US_Doctor.Models;
using HealthCare.Areas.Devices.Models;
using HealthCare.BAL;
using HealthCare.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
namespace HealthCare.Areas.Devices.Controllers
{
    [CheckAccess]
    [Area("Devices")]
    [Route("Devices/[controller]/[action]")]

    public class DevicesController : Controller
    {
        #region Index
        public IActionResult Index()
        {
           Device_DALBASE ds = new Device_DALBASE();
           DataTable dt = ds.PR_Device_SelectAll();
            return View("DeviceList", dt);
        }
        #endregion

        #region Add
        public IActionResult Add(int? DeviceID)
        {
            Device_DALBASE Ddal = new Device_DALBASE();
            if (DeviceID != null)
            {
                DataTable dt = Ddal.PR_Device_SelectByPK(DeviceID);
                if (dt.Rows.Count > 0)
                {
                    DevicesModel de = new DevicesModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        de.DeviceID = Convert.ToInt32(dr["DeviceID"]);
                        de.DeviceName = dr["DeviceName"].ToString();
                        de.DeviceBrand = dr["DeviceBrand"].ToString();
                        de.PhotoPath = dr["PhotoPath"].ToString();
                        de.Price = dr["Price"].ToString();
                        de.Description = dr["Description"].ToString();
                    }
                    return View("DeviceAddEdit", de);
                }
            }
            return View("DeviceAddEdit");

        }
        #endregion

        #region Save
        public IActionResult Save(DevicesModel doct)

        {
            #region img
            if (doct.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNamewithPath = Path.Combine(path, doct.File.FileName);
                doct.PhotoPath = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + doct.File.FileName;

                using (var stream = new FileStream(fileNamewithPath, FileMode.Create))
                {
                    doct.File.CopyTo(stream);
                }
            }
            #endregion

            Device_DALBASE ddal = new Device_DALBASE();
            if (doct.DeviceID == null)
            {
                DataTable dt = ddal.PR_Device_Insert(doct);
                TempData["AlertMsg"] = "Record Inserted Succesfully";

            }
            else
            {               
                  DataTable dt = ddal.PR_Device_Update(doct);
                  TempData["AlertMsg"] = "Record Updated Succesfully";               
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int DeviceID)
        {
            Device_DALBASE ddal = new Device_DALBASE();

            if (Convert.ToBoolean(ddal.PR_Device_Delete(DeviceID)))
            {
                TempData["AlertMsg"] = "Record Deleted Successfully";
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
