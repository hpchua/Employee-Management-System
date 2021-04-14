using Employee_Management_System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Employee_Management_System.DA
{
    public class PositionDA
    {
        private static readonly EmployeeDbContext db = new EmployeeDbContext();

        public static SelectList GetPositions(object selectedValue = null)
        {
            try
            {
                return new SelectList(
                    items: db.Positions.ToList(),
                    dataValueField: "ID",
                    dataTextField: "PositionName",
                    selectedValue: selectedValue
                );
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static string GetNameByID(long positionID)
        {
            try
            {
                var position = db.Positions.Find(positionID);
                return position.PositionName;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}