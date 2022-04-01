using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Asp.net.Api.Models
{
    public class Pupil
    {
        public int Pupilid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumer { get; set; }
        public int? Classid { get; set; }
        public Class Class { get; set; }
    }
}
