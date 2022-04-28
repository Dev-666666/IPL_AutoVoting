using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IPLVotingSystem.Models
{
    [Table("Options")]
    public class Options
    {
        [Required]
        [Key]
        public int optionId{ get; set; }
        [ForeignKey("Questionary")]
        public int  qId { get; set; }
        [Required]
        public string  option1 { get; set; }
        [Required]
        public string option2 { get; set; }
        [Required]
        public string  option3 { get; set; }
        [Required]
        public string  option4 { get; set; }
    }
}
