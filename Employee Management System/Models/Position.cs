using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.Models
{
    [Table("Position")]
    public class Position
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PositionName { get; set; }
    }
}