using Employee_Management_System.Models;
using System.Data.Entity;

namespace Employee_Management_System.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("EmployeeManagementDB")
        {
        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BlockIPAddress> BlockIPAddresses { get; set; }
    }
}