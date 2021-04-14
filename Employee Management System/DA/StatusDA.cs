using Employee_Management_System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Employee_Management_System.DA
{
    public class StatusDA
    {
        private static readonly EmployeeDbContext db = new EmployeeDbContext();

        public static SelectList GetStatuses(object selectedValue = null)
        {
            try
            {
                return new SelectList(
                    items: db.Statuses.ToList(),
                    dataValueField: "ID",
                    dataTextField: "StatusName",
                    selectedValue: selectedValue
                );
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static string GetNameByID(long statusID)
        {
            try
            {
                var status = db.Statuses.Find(statusID);
                return status.StatusName;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}