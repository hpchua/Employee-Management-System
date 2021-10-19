using Employee_Management_System.Data;
using Employee_Management_System.Models;
using Employee_Management_System.Models.ViewModels;
using Employee_Management_System.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Employee_Management_System.DA
{
    public static class EmployeeDA
    {
        private static readonly EmployeeDbContext db = new EmployeeDbContext();

        public static Employee GetEmployeeByUsername(string username)
        {
            try
            {
                return db.Employees.Where(e => e.Username.ToLower().Equals(username.ToLower())).FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static List<Employee> GetAll(string searchString, string sortColumnName, string sortDirection, int start, int length, out int totalCount, out int totalRowsAfterFilter)
        {
            try
            {
                IEnumerable<Employee> employeeList = db.Employees.Include("Position").Include("Status").Include("Team");

                totalCount = employeeList.Count();   // Return total number of employees

                #region Filter
                if (!String.IsNullOrEmpty(searchString))
                {
                    string search = searchString.ToLower();

                    DateTime dateTime;

                    if (DateTime.TryParse(search, out dateTime))
                    {
                        employeeList = employeeList.Where(e => e.Username.ToLower().Contains(search) ||
                                                           e.FullName.ToLower().Contains(search) ||
                                                           e.JoinedDate == Convert.ToDateTime(search) ||
                                                           e.Team.TeamName.ToLower().Contains(search) ||
                                                           e.Position.PositionName.ToLower().Contains(search) ||
                                                           e.Status.StatusName.ToLower().Contains(search));
                    }
                    else
                    {
                        employeeList = employeeList.Where(e => e.Username.ToLower().Contains(search) ||
                                                           e.FullName.ToLower().Contains(search) ||
                                                           e.Team.TeamName.ToLower().Contains(search) ||
                                                           e.Position.PositionName.ToLower().Contains(search) ||
                                                           e.Status.StatusName.ToLower().Contains(search));
                    }
                }
                totalRowsAfterFilter = employeeList.Count();
                #endregion

                #region Sorting
                if (!(String.IsNullOrEmpty(sortColumnName) && String.IsNullOrEmpty(sortDirection)))
                {
                    if (sortDirection.Equals("asc"))
                    {
                        switch (sortColumnName)
                        {
                            case SD.SortOrderParameter.FullName:
                                employeeList = employeeList.OrderBy(e => e.FullName);
                                break;
                            case SD.SortOrderParameter.JoinedDate:
                                employeeList = employeeList.OrderBy(e => e.JoinedDate);
                                break;
                            case SD.SortOrderParameter.Team:
                                employeeList = employeeList.OrderBy(e => e.Team.TeamName);
                                break;
                            case SD.SortOrderParameter.Position:
                                employeeList = employeeList.OrderBy(e => e.Position.PositionName);
                                break;
                            case SD.SortOrderParameter.Status:
                                employeeList = employeeList.OrderBy(e => e.Status.StatusName);
                                break;
                            default:
                                employeeList = employeeList.OrderBy(e => e.Username);
                                break;
                        }
                    }
                    else
                    {
                        switch (sortColumnName)
                        {
                            case SD.SortOrderParameter.FullName:
                                employeeList = employeeList.OrderByDescending(e => e.FullName);
                                break;
                            case SD.SortOrderParameter.JoinedDate:
                                employeeList = employeeList.OrderByDescending(e => e.JoinedDate);
                                break;
                            case SD.SortOrderParameter.Team:
                                employeeList = employeeList.OrderByDescending(e => e.Team.TeamName);
                                break;
                            case SD.SortOrderParameter.Position:
                                employeeList = employeeList.OrderByDescending(e => e.Position.PositionName);
                                break;
                            case SD.SortOrderParameter.Status:
                                employeeList = employeeList.OrderByDescending(e => e.Status.StatusName);
                                break;
                            default:
                                employeeList = employeeList.OrderByDescending(e => e.Username);
                                break;
                        }
                    }
                }
                #endregion

                #region Paging
                if (start != 0 && length != 0)
                    employeeList = employeeList.Skip(start).Take(length);
                #endregion

                return (List<Employee>)employeeList.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void SaveIPAddress(Employee employee, string ipAddress)
        {
            try
            {
                employee.IPAddress = ipAddress;
                employee.LoginAttempt = SD.DEFAULT_LOGIN_ATTEMPT;

                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static byte AddLoginAttemptNumber(Employee employee, string ipV4)
        {
            try
            {
                employee.LoginAttempt++;
                db.SaveChanges();

                if (employee.LoginAttempt >= 5 && employee.LoginAttempt < 10)
                {
                    employee.StatusID = SD.DISABLED_STATUS_ID;
                    db.SaveChanges();
                }
                else if (employee.LoginAttempt >= 10)
                {
                    employee.StatusID = SD.SUSPENDED_STATUS_ID;
                    db.SaveChanges();

                    BlockIPAddressDA.Add(ipV4);
                }
                return employee.LoginAttempt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool IsEmployeeIDExists(long employeeID)
        {
            try
            {
                return !db.Employees.Any(e => e.ID == employeeID);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void AddNewEmployee(Employee newEmployee)
        {
            try
            {
                db.Employees.Add(newEmployee);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void UpdateExistingEmployee(string username, EditEmployeeVM employeeToUpdate)
        {
            try
            {
                var currentEmployee = db.Employees.Where(e => e.Username.ToLower().Equals(username.ToLower())).FirstOrDefault();

                currentEmployee.Email = employeeToUpdate.Email;
                currentEmployee.FullName = employeeToUpdate.FullName;
                currentEmployee.Password = employeeToUpdate.Password;
                currentEmployee.JoinedDate = employeeToUpdate.JoinedDate;
                currentEmployee.PositionID = employeeToUpdate.PositionID;
                currentEmployee.TeamID = employeeToUpdate.TeamID;
                currentEmployee.StatusID = employeeToUpdate.StatusID;
                currentEmployee.SecurityPhase = employeeToUpdate.SecurityPhase;

                switch (employeeToUpdate.StatusID)
                {
                    case SD.ACTIVE_STATUS_ID:
                        currentEmployee.LoginAttempt = SD.DEFAULT_LOGIN_ATTEMPT;
                        break;
                    case SD.DISABLED_STATUS_ID:
                        currentEmployee.LoginAttempt = SD.DISABLED_LOGIN_ATTEMPT;
                        break;
                    default:
                        currentEmployee.LoginAttempt = SD.MAXIMUM_LOGIN_ATTEMPT;
                        break;
                }

                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void DeleteEmployee(long employeeID)
        {
            try
            {
                Employee employeeToDelete = db.Employees.Find(employeeID);

                if (employeeToDelete != null)
                {
                    db.Employees.Remove(employeeToDelete);
                    db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}