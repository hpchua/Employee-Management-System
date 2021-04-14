using Employee_Management_System.Data;
using Employee_Management_System.Models;
using System.Data.SqlClient;

namespace Employee_Management_System.DA
{
    public static class BlockIPAddressDA
    {
        private static readonly EmployeeDbContext db = new EmployeeDbContext();

        public static BlockIPAddress Get(string UserIPAddress)
        {
            try
            {
                return db.BlockIPAddresses.Find(UserIPAddress);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static void Add(string UserIPAddress)
        {
            try
            {
                db.BlockIPAddresses.Add(new BlockIPAddress()
                {
                    IPAddress = UserIPAddress
                });
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}