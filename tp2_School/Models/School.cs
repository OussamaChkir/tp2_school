using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2_School.Models
{
    public class School
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAdress { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
