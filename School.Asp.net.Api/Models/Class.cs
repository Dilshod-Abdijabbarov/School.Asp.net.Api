using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Asp.net.Api.Models
{
    public class Class
    {


        public Class()
        {
            Pupil = new HashSet<Pupil>();
        }
        public int Classid { get; set; }
        public int ClassCourse { get; set; }
        public string  ClassType { get; set; }
        public ICollection<Pupil> Pupil { get; set; }
        
    }
}
