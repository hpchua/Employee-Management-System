using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.Models
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }
    }
}