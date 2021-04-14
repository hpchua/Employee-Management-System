using Employee_Management_System.CustomAuthorization;
using Employee_Management_System.DA;
using Employee_Management_System.Models.ViewModels;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    [AccountAuthorization]
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            #region Datatable Server Side Parameter
            // Source : https://datatables.net/manual/server-side
            int start = Convert.ToInt32(Request["start"]);      // Paging Index
            int length = Convert.ToInt32(Request["length"]);    // Number of Records
            string searchValue = Request["search[value]"];      // Search String 
            string sortColumnName = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            string sortDirection = Request["order[0][dir]"];   // Ascending or Descending order
            #endregion

            var employees = EmployeeDA.GetAll(searchValue, sortColumnName, sortDirection, start, length, out int totalCount, out int totalRowsAfterFilter);

            return Json(new { data = employees, draw = Request["draw"], recordsTotal = totalCount, recordsFiltered = totalRowsAfterFilter }, JsonRequestBehavior.AllowGet);
        }

        private void GenerateDropDownList()
        {
            ViewBag.PositionSelectList = PositionDA.GetPositions();
            ViewBag.TeamSelectList = TeamDA.GetTeams();
            ViewBag.StatusSelectList = StatusDA.GetStatuses();
        }

        [HttpGet]
        public ActionResult Create()
        {
            GenerateDropDownList();
            return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Username,Email,FullName,Password,ComfirmPassword,JoinedDate,PositionID,TeamID,SecurityPhase")] CreateEmployeeVM newEmployee)
        {
            GenerateDropDownList();

            var newEmployeeData = EmployeeViewModel.InsertData(newEmployee);
            EmployeeDA.AddNewEmployee(newEmployeeData);

            return Json(new { success = true, message = "Created Successfully!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IsUsernameUnique(string username)
        {
            bool isUnique;
            var usernameExists = EmployeeDA.GetEmployeeByUsername(username);

            if (usernameExists == null)
            {
                isUnique = true;
                //return Json("<img src='~/Content/images/right.gif' width='16' title='Available'/>");
            }
            else
            {
                isUnique = false;
                //return Json("<img src='~/Content/images/wrong.gif' width='16' title='Already in used!'/>");
            }
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IsEmployeeIDUnique(long employeeID)
        {
            return Json(EmployeeDA.IsEmployeeIDExists(employeeID), JsonRequestBehavior.AllowGet);

            /*
            var idExists = EmployeeDA.IsEmployeeIDExists(employeeID);

            if (idExists)
            {
                return Json("<img src='~/Content/images/right.gif' width='16' title='Available'/>");
            }
            else
            {
                return Json("<img src='~/Content/images/wrong.gif' width='16' title='Already in used!'/>");
            }
            */
        }

        [HttpGet]
        public ActionResult Edit(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var existingEmployee = EmployeeDA.GetEmployeeByUsername(username);

            if (existingEmployee == null)
            {
                return HttpNotFound();
            }

            var model = EmployeeViewModel.FetchExistingEmployeeData(existingEmployee);
            GenerateDropDownList();
            return View(model);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,EmployeeID,Email,FullName,Password,ComfirmPassword,JoinedDate,PositionID,TeamID,StatusID,SecurityPhase")] EditEmployeeVM existingEmployee)
        {
            GenerateDropDownList();

            var employeeToUpdate = EmployeeViewModel.UpdateData(existingEmployee);
            EmployeeDA.UpdateExistingEmployee(employeeToUpdate.Username, existingEmployee);

            return Json(new { success = true, message = "Updated Successfully!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(string username)
        {
            var existingEmployee = EmployeeDA.GetEmployeeByUsername(username);
            var model = EmployeeViewModel.FetchExistingDeleteEmployeeData(existingEmployee);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteEmployeeVM deleteEmployeeVM)
        {
            EmployeeDA.DeleteEmployee(deleteEmployeeVM.EmployeeID);
            return Json(new { success = true, message = "Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
        }
    }
}