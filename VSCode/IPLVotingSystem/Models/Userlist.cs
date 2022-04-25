using System;
using System.Collections.Generic;
using System.Linq;
using IPLVotingSystem;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IPLVotingSystem.Models
{
    [Table("userlist")]
    public class Userlist
    {
        
        [Required]
        [Key]
        public int uid{ get; set; }
        
        [Required(ErrorMessage ="Please Enter the Username")]
        [DataType(DataType.Text)]
        public string uname { get; set; }
        [Required(ErrorMessage ="Plese Enter the Password")]
        [DataType(DataType.Password)]
        
        public string  pass { get; set; }
        [Required]
        public string fullname { get; set; }
    }
}
