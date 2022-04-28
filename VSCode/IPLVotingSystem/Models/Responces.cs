using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPLVotingSystem.Models
{
    [Table("Responces")]
    public class Responces
    {
       
        [Key]
        public int Id { get; set; }
        public int QId { get; set; }
        public int UId { get; set; }
    }
}
