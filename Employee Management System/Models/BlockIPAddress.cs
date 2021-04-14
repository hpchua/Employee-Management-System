using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.Models
{
    [Table("BlockIPAddress")]
    public class BlockIPAddress
    {
        [Key]
        [Column(TypeName = "VARCHAR")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]    //No Auto Generate      
        [StringLength(15)]
        public string IPAddress { get; set; }
    }
}