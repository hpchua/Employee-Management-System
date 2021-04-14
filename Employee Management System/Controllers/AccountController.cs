using Employee_Management_System.DA;
using Employee_Management_System.Models;
using Employee_Management_System.Models.ViewModels;
using Employee_Management_System.Utils;
using System;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login(string reason)
        {
            if (Session["EmployeeID"] != null)
                return RedirectToAction("List", "Employee");

            if (reason != null)
                ModelState.AddModelError("", reason);

            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel input)
        {
            if (ModelState.IsValid)
            {
                var verifiedEmployee = EmployeeDA.GetEmployeeByUsername(input.Username);

                if (verifiedEmployee != null)
                {
                    if (IsValid(verifiedEmployee, input.Password))
                    {
                        EmployeeDA.SaveIPAddress(verifiedEmployee, Request.UserHostAddress);

                        #region Create Session and Cookie
                        Session["EmployeeID"] = verifiedEmployee.ID;
                        Session["Username"] = verifiedEmployee.Username;

                        var cookie = new HttpCookie("EmployeeID")
                        {
                            Value = verifiedEmployee.ID.ToString(),
                            Expires = DateTime.UtcNow.AddDays(1), // 1 day
                        };
                        Response.Cookies.Add(cookie);
                        #endregion

                        return RedirectToAction("Index", "Employee");
                    }
                }
                else
                {
                    ViewBag.Message = "Invalid username / password";
                }
            }

            System.Threading.Thread.Sleep(2000); // 2 seconds
            return View("Login", input);
        }

        public ActionResult Logout()
        {
            #region Clear Session and Cookie
            Session.Clear();
            Response.Cookies.Clear();
            #endregion

            return View("Login");
        }

        private bool IsValid(Employee employee, string password)
        {
            int isCredentialValid = CheckLoginCredential(employee, password);
            bool isIPValid = CheckBlockIP();
            bool isStatusAcitve = CheckStatus(employee);

            if (!isIPValid)
            {
                ModelState.AddModelError(string.Empty, "Unable to log in from disallowed IP address");
                return false;
            }

            if (isCredentialValid != SD.DEFAULT_LOGIN_ATTEMPT)
            {
                int loginAttempt = isCredentialValid;

                if (loginAttempt < SD.DISABLED_LOGIN_ATTEMPT)
                {
                    ModelState.AddModelError(string.Empty, $"Invalid password. You have failed {loginAttempt} login attempts, your account is going to be disabled soon");
                }
                else if (loginAttempt >= SD.DISABLED_LOGIN_ATTEMPT && loginAttempt < SD.MAXIMUM_LOGIN_ATTEMPT)
                {
                    ModelState.AddModelError(string.Empty, $"Invalid password. You have failed {loginAttempt} login attempts, your account is going to be suspended soon");
                }
                return false;
            }

            if (!isStatusAcitve)
            {
                ModelState.AddModelError(string.Empty, "Your account has been suspended, please contact admin to recover");
                return false;
            }

            return true;
        }

        private int CheckLoginCredential(Employee employee, string password)
        {
            if (employee.Password.ToLower() != password.ToLower())
                return EmployeeDA.AddLoginAttemptNumber(employee, Request.UserHostAddress);

            return 0;
        }

        private bool CheckBlockIP()
        {
            if (BlockIPAddressDA.Get(Request.UserHostAddress) != null)
                return false;

            return true;
        }

        private bool CheckStatus(Employee employee)
        {
            if (employee.StatusID != SD.ACTIVE_STATUS_ID)
                return false;

            return true;
        }
    }
}