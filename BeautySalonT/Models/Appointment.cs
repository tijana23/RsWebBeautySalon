using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalonT.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        [Display(Name = "Time")]
        public string Time { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}
