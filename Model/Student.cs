using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Model
{
    public class Student
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public int Age { get; set; }

        public List<Module>? SelModules;


        public double GPA { get; set; }



    }
}
