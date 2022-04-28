using System;
using System.Collections.Generic;
using System.Linq;
using IPLVotingSystem;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IPLVotingSystem.Models
{
    [Table("Users")]
    public class Users
    {
        
        [Required]
        [Key]
        public int UId{ get; set; }
        
        [Required(ErrorMessage ="Please Enter the Username")]
        [DataType(DataType.Text)]
        [Display(Name ="User Name")]
        public string UName { get; set; }
   
        [ForeignKey("UserRoles")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Plese Enter the Password")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
