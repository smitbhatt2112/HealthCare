using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;
using System.Configuration;
using HealthCare.Dal;

namespace HealthCare.Controllers
{


    public class User_MasterController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public User_MasterController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        #endregion



        #region Login
        [HttpPost]
        public IActionResult Login(User_MasterModel d)
        {
            string conn = Configuration.GetConnectionString("myConnectionStrings");
            string error = null;
            if (d.UserName == null)
            {
                error += "User Name is required";
            }
            if (d.Password == null)
            {
                error += "<br/>Password is required";
            }

            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("Index");
            }
            else
            {
                Master_Dal dalMaster = new Master_Dal();
                DataTable dt = dalMaster.dbo_PR_User_Master_SelectByUserNamePassword(conn, d.UserName, d.Password);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("Index");
                }
                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        #endregion

        #region UserDetails
        public IActionResult UserDetails()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Master_Dal dalMLT = new Master_Dal();
            DataTable dt = dalMLT.User_Select(connectionstr, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            return View("User_Details", dt);

        }

        #endregion

        #region EditUser
        public IActionResult EditUser(int? UserId)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Master_Dal dalMLT = new Master_Dal();


            if (Convert.ToInt32(HttpContext.Session.GetString("UserID")) != null)
            {
                DataTable dt = dalMLT.dbo_PR_User_Master_SelectByPK(connectionstr, Convert.ToInt32(HttpContext.Session.GetString("UserID")));

                if (dt.Rows.Count > 0)
                {
                    User_MasterModel modelMLT_User = new User_MasterModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelMLT_User.UserID = Convert.ToInt32(dr["UserID"]);
                        modelMLT_User.UserName = dr["UserName"].ToString();
                        modelMLT_User.Password = dr["Password"].ToString();
                        modelMLT_User.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        modelMLT_User.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                    }
                    return View("User_Edit", modelMLT_User);
                }
            }

            return View("User_Edit");
        }
        #endregion

        #region Save
        public IActionResult Save(User_MasterModel modelMLT_User)

        {

            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Master_Dal dalMLT = new Master_Dal();

            if (Convert.ToInt32(HttpContext.Session.GetString("UserID")) == null)
            {
                if (Convert.ToBoolean(dalMLT.PR_MLT_User_Insert(connectionstr, modelMLT_User, Convert.ToInt32(HttpContext.Session.GetString("UserID")))))
                    TempData["AlertMsg"] = "Record Inserted Successfully";

            }
            else
            {

                if (Convert.ToBoolean(dalMLT.PR_MLT_User_Update(connectionstr, modelMLT_User, Convert.ToInt32(HttpContext.Session.GetString("UserID")))))
                    TempData["AlertMsg"] = "Record Update Successfully";
            }
            return RedirectToAction("UserDetails");




        }


        #endregion

        #region AddUser
        public IActionResult AddUser(User_MasterModel modelUser_Master)
        {

            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Master_Dal dalMLT = new Master_Dal();

            if (Convert.ToBoolean(dalMLT.PR_MLT_User_Insert(connectionstr, modelUser_Master, Convert.ToInt32(HttpContext.Session.GetString("UserID")))))
                TempData["AlertMsg"] = "Record Insert Successfully";

            return View("RegisterUser");
        }
        #endregion

        #region SaveUser
        public IActionResult SaveUser(User_MasterModel modelMLT_User)

        {

            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            Master_Dal dalMLT = new Master_Dal();


            if (Convert.ToBoolean(dalMLT.PR_MLT_User_Insert(connectionstr, modelMLT_User, Convert.ToInt32(HttpContext.Session.GetString("UserID")))))
                TempData["AlertMsg"] = "Record Inserted Successfully";

            return RedirectToAction("Index");




        }


        #endregion


    }




}
