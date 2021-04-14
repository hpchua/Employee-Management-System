using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   //No Auto Generate
        [Display(Name = "Employee ID")]
        public long ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Username { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Joined Date")]
        public DateTime JoinedDate { get; set; }

        [Required]
        [StringLength(40)]
        public string SecurityPhase { get; set; }

        public byte LoginAttempt { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string IPAddress { get; set; }

        [Required]
        public long PositionID { get; set; }

        [ForeignKey("PositionID")]
        public Position Position { get; set; }

        [Required]
        public long TeamID { get; set; }

        [ForeignKey("TeamID")]
        public Team Team { get; set; }

        [Required]
        public long StatusID { get; set; }

        [ForeignKey("StatusID")]
        public Status Status { get; set; }
    }
}