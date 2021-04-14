using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [StringLength(20)]
        public string StatusName { get; set; }
    }
}