using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalonT.Models
{
    public class Client
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Telephone number")]
        public int TelephoneNumber { get; set; }
        public ICollection<Appointment> Services { get; set; }
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
        public string ProfilePicture { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
