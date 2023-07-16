using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Model
{
   public class Result
   {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ModuleID { get; set; }
        [Required]
        public int StudentID { get; set; }
        public double Grade { get; set; }


    }
}
