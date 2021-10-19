using Employee_Management_System.DA;
using Employee_Management_System.Utils;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Employee_Management_System.Models.ViewModels
{
    public static class EmployeeViewModel
    {
        #region Create
        public static Employee InsertData(CreateEmployeeVM newEmployee)
        {
            return new Employee
            {
                Username = newEmployee.Username,
                Password = newEmployee.Password,
                ID = newEmployee.EmployeeID,
                Email = newEmployee.Email,
                FullName = newEmployee.FullName,
                JoinedDate = newEmployee.JoinedDate,
                SecurityPhase = newEmployee.SecurityPhase,
                IPAddress = "",
                LoginAttempt = SD.DEFAULT_LOGIN_ATTEMPT,
                PositionID = newEmployee.PositionID,
                TeamID = newEmployee.TeamID,
                StatusID = SD.ACTIVE_STATUS_ID,
            };
        }
        #endregion

        #region Edit
        public static EditEmployeeVM FetchExistingEmployeeData(Employee existingEmployee)
        {
            return new EditEmployeeVM
            {
                Username = existingEmployee.Username,
                Password = existingEmployee.Password,
                EmployeeID = existingEmployee.ID,
                Email = existingEmployee.Email,
                FullName = existingEmployee.FullName,
                JoinedDate = existingEmployee.JoinedDate,
                SecurityPhase = existingEmployee.SecurityPhase,
                PositionID = existingEmployee.PositionID,
                TeamID = existingEmployee.TeamID,
                StatusID = existingEmployee.StatusID
            };
        }

        public static Employee UpdateData(EditEmployeeVM existingEmployee)
        {
            return new Employee
            {
                Username = existingEmployee.Username,
                Password = existingEmployee.Password,
                ID = existingEmployee.EmployeeID,
                Email = existingEmployee.Email,
                FullName = existingEmployee.FullName,
                JoinedDate = existingEmployee.JoinedDate,
                SecurityPhase = existingEmployee.SecurityPhase,
                PositionID = existingEmployee.PositionID,
                TeamID = existingEmployee.TeamID,
                StatusID = existingEmployee.StatusID
            };
        }
        #endregion

        #region Delete
        public static DeleteEmployeeVM FetchExistingDeleteEmployeeData(Employee existingEmployee)
        {
            return new DeleteEmployeeVM
            {
                Username = existingEmployee.Username,
                EmployeeID = existingEmployee.ID,
                Email = existingEmployee.Email,
                FullName = existingEmployee.FullName,
                JoinedDate = existingEmployee.JoinedDate,
                PositionName = PositionDA.GetNameByID(existingEmployee.PositionID),
                TeamName = TeamDA.GetNameByID(existingEmployee.TeamID),
                StatusName = StatusDA.GetNameByID(existingEmployee.StatusID),
            };
        }
        #endregion
    }

    //Edit Employee
    public class EditEmployeeVM
    {
        public string Username { get; set; }

        [DisplayName("Employee ID")]
        public long EmployeeID { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please fill in password.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,15}$", ErrorMessage = "Password must be 8-15 characters, and include letters and numbers.")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please fill in confirm password.")]
        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "The password fields did not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please fill in email address.")]
        [EmailAddress(ErrorMessage = "This email address is not valid.")]
        public string Email { get; set; }

        [DisplayName("Full Name")]
        [StringLength(20, ErrorMessage = "Full name must not exceed 20 characters")]
        public string FullName { get; set; }

        [DisplayName("Joined Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please fill in join date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime JoinedDate { get; set; }

        [DisplayName("Security Phase")]
        [Required(ErrorMessage = "Please fill in security phase.")]
        [StringLength(40, ErrorMessage = "Security phase must not exceed 40 characters.")]
        public string SecurityPhase { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Please select a position")]
        public long PositionID { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please select a Status")]
        public long StatusID { get; set; }

        [Display(Name = "Team")]
        [Required(ErrorMessage = "Please select a team")]
        public long TeamID { get; set; }
    }

    //Create Employee
    public class CreateEmployeeVM
    {
        [Required(ErrorMessage = "Please fill in username.")]
        [Remote(action: "IsUsernameUnique", controller: "Employee", ErrorMessage = "This username has already been registered. Please enter a different username.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,15}$", ErrorMessage = "Username must be 8-15 characters, and include letters and numbers.")]
        public string Username { get; set; }

        [DisplayName("Employee ID")]
        [Remote(action: "IsEmployeeIDUnique", controller: "Employee", ErrorMessage = "This employee ID has already been registered. Please enter a different username.")]
        [Required(ErrorMessage = "Please fill in employee ID.")]
        [Range(1, 1000_000_000, ErrorMessage = "Employee ID must be 1-10 numbers.")]
        public long EmployeeID { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please fill in password.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,15}$", ErrorMessage = "Password must be 8-15 characters, and include letters and numbers.")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please fill in confirm password.")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password fields did not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please fill in email address.")]
        [EmailAddress(ErrorMessage = "This email address is not valid.")]
        public string Email { get; set; }

        [DisplayName("Full Name")]
        [StringLength(20, ErrorMessage = "Full name must not exceed 20 characters")]
        public string FullName { get; set; }

        [DisplayName("Joined Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please fill in join date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime JoinedDate { get; set; }

        [DisplayName("Security Phase")]
        [Required(ErrorMessage = "Please fill in security phase.")]
        [StringLength(40, ErrorMessage = "Security phase must not exceed 40 characters.")]
        public string SecurityPhase { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Please select a position")]
        public long PositionID { get; set; }

        [Display(Name = "Team")]
        [Required(ErrorMessage = "Please select a team")]
        public long TeamID { get; set; }
    }

    //Delete Employee
    public class DeleteEmployeeVM
    {
        public string Username { get; set; }

        [DisplayName("Employee ID")]
        public long EmployeeID { get; set; }

        public string Email { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Joined Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime JoinedDate { get; set; }

        [Display(Name = "Position")]
        public string PositionName { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }
    }
}