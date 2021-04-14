using Employee_Management_System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Employee_Management_System.DA
{
    public class TeamDA
    {
        private static readonly EmployeeDbContext db = new EmployeeDbContext();

        public static SelectList GetTeams(object selectedValue = null)
        {
            try
            {
                return new SelectList(
                    items: db.Teams.ToList(),
                    dataValueField: "ID",
                    dataTextField: "TeamName",
                    selectedValue: selectedValue
                );
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static string GetNameByID(long teamID)
        {
            try
            {
                var team = db.Teams.Find(teamID);
                return team.TeamName;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}