using Employee_Management_System.Data;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Employee_Management_System.CustomAuthorization
{
    public class AccountAuthorization : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext context)
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var employeeID = context.HttpContext.Session["EmployeeID"];
                var employeeUsername = context.HttpContext.Session["Username"];

                if (employeeID == null && employeeUsername == null)
                {
                    context.Result = new HttpUnauthorizedResult("Unauthorized access. Please login into your account first.");
                }
                else if (db.Employees.Find(employeeID).IPAddress != context.HttpContext.Request.UserHostAddress)
                {
                    context.HttpContext.Session.Clear();
                    context.Result = new HttpUnauthorizedResult("Automatically logged out due to multiple login detected.");
                }
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if (context.Result == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Account" },
                        { "action", "Login" },
                    }
                );
            }
            else if (context.Result is HttpUnauthorizedResult result)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Account" },
                        { "action", "Login" },
                        { "reason", result.StatusDescription},
                    }
                );
            }
        }
    }
}