namespace Employee_Management_System.Migrations
{
    using Employee_Management_System.Data;
    using Employee_Management_System.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Employee_Management_System.Data.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Employee_Management_System.Data.EmployeeDbContext context)
        {
            AddEmployees(context);
            AddPositions(context);
            AddStatuses(context);
            AddTeams(context);
        }

        private void AddEmployees(EmployeeDbContext context)
        {
            context.Employees.AddOrUpdate(
                new Employee()
                {
                    ID = 1001,
                    Username = "employee1",
                    Password = "testing123",
                    Email = "employee1@gmail.com",
                    FullName = "Employee One",
                    JoinedDate = DateTime.Today.AddDays(-10),
                    SecurityPhase = "Security Phase For Employee 1",
                    LoginAttempt = 0,
                    PositionID = 1,
                    TeamID = 1,
                    StatusID = 1,
                },
                new Employee()
                {
                    ID = 1002,
                    Username = "employee2",
                    Password = "testing123",
                    Email = "employee2@gmail.com",
                    FullName = "Employee Two",
                    JoinedDate = DateTime.Today.AddDays(-20),
                    SecurityPhase = "Security Phase For Employee 2",
                    LoginAttempt = 0,
                    PositionID = 2,
                    TeamID = 2,
                    StatusID = 1,
                },
                new Employee()
                {
                    ID = 1003,
                    Username = "employee3",
                    Password = "testing123",
                    Email = "employee3@gmail.com",
                    FullName = "Employee Three",
                    JoinedDate = DateTime.Today.AddDays(-30),
                    SecurityPhase = "Security Phase For Employee 3",
                    LoginAttempt = 0,
                    PositionID = 3,
                    TeamID = 3,
                    StatusID = 1,
                },
                new Employee()
                {
                    ID = 1004,
                    Username = "employee4",
                    Password = "testing123",
                    Email = "employee4@gmail.com",
                    FullName = "Employee Four",
                    JoinedDate = DateTime.Today.AddDays(-40),
                    SecurityPhase = "Security Phase For Employee 4",
                    LoginAttempt = 0,
                    PositionID = 4,
                    TeamID = 4,
                    StatusID = 1,
                },
                new Employee()
                {
                    ID = 1005,
                    Username = "employee5",
                    Password = "testing123",
                    Email = "employee5@gmail.com",
                    FullName = "Employee Five",
                    JoinedDate = DateTime.Today.AddDays(-50),
                    SecurityPhase = "Security Phase For Employee 5",
                    LoginAttempt = 0,
                    PositionID = 5,
                    TeamID = 5,
                    StatusID = 1,
                });
        }

        private void AddPositions(EmployeeDbContext context)
        {
            context.Positions.AddOrUpdate(
                new Position()
                {
                    ID = 1,
                    PositionName = "Director",
                },
                new Position()
                {
                    ID = 2,
                    PositionName = "Human Resource",
                },
                new Position()
                {
                    ID = 3,
                    PositionName = "Finance",
                },
                new Position()
                {
                    ID = 4,
                    PositionName = "Admin",
                },
                new Position()
                {
                    ID = 5,
                    PositionName = "Manager",
                },
                new Position()
                {
                    ID = 6,
                    PositionName = "Quality Assurance Engineer",
                },
                new Position()
                {
                    ID = 7,
                    PositionName = "Solution Architect",
                },
                new Position()
                {
                    ID = 8,
                    PositionName = "Business Analysis",
                },
                new Position()
                {
                    ID = 9,
                    PositionName = "Art Director",
                },
                new Position()
                {
                    ID = 10,
                    PositionName = "Team Lead",
                },
                new Position()
                {
                    ID = 11,
                    PositionName = "Senior Software Engineer",
                },
                new Position()
                {
                    ID = 12,
                    PositionName = "Software Engineer",
                },
                new Position()
                {
                    ID = 13,
                    PositionName = "UI Engineer",
                },
                new Position()
                {
                    ID = 14,
                    PositionName = "Support Engineer",
                },
                new Position()
                {
                    ID = 15,
                    PositionName = "Infrastructure Support Engineer",
                });
        }

        private void AddTeams(EmployeeDbContext context)
        {
            context.Teams.AddOrUpdate(
                new Team()
                {
                    ID = 1,
                    TeamName = "Operation",
                },
                new Team()
                {
                    ID = 2,
                    TeamName = "Architect",
                },
                new Team()
                {
                    ID = 3,
                    TeamName = "Designer",
                },
                new Team()
                {
                    ID = 4,
                    TeamName = "Development",
                },
                new Team()
                {
                    ID = 5,
                    TeamName = "Infrastructure Support",
                },
                new Team()
                {
                    ID = 6,
                    TeamName = "Production Support",
                },
                new Team()
                {
                    ID = 6,
                    TeamName = "Quality Assurance",
                });
        }

        private void AddStatuses(EmployeeDbContext context)
        {
            context.Statuses.AddOrUpdate(
                new Status()
                {
                    ID = 1,
                    StatusName = "Active",
                },
                new Status()
                {
                    ID = 2,
                    StatusName = "Disabled",
                },
                new Status()
                {
                    ID = 3,
                    StatusName = "Suspended",
                });
        }
    }
}
