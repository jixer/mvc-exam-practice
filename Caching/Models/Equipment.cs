using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chris.Samples.MvcExam.Caching.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public Technician Technician { get; set; }
    }
}