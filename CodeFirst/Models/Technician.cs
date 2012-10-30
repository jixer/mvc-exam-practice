using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chris.Samples.MvcExam.CodeFirst.Models
{
    public class Technician
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}