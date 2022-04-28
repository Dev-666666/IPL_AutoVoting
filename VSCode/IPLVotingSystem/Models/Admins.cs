using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace IPLVotingSystem.Models
{
    [Table("Admins")]
    public class Admins
    {
        [Key]
        [Required]
        public int AdminId { get; set; }
        [Required]
        public string AdminName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
        [ForeignKey("UserRole")]
        public int RoleId { get; set; }
    }
}
