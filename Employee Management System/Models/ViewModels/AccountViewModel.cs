using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Models.ViewModels
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Please fill-in username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please fill-in password")]
        public string Password { get; set; }
    }
}