using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalonT.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Price { get; set; }
        public ICollection<Appointment> Client { get; set; }
        public ICollection<EmployeeService> Employee { get; set; }
    }
}
