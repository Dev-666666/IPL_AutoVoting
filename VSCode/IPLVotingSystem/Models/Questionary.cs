using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using IPLVotingSystem.Models;

namespace IPLVotingSystem.Models
{
    [Table("Questionary")]
    public class Questionary
    {
        [Key]
        [Required]
        public int qId { get; set; }
        [Required]
        public string Question { get; set; }

    }
}
