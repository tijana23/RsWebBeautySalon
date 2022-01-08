using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalonT.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [MaxLength(50)]
        [Display(Name = "SSN")]
        public string SSN { get; set; }
        [MaxLength(50)]
        [Display(Name = "Licence")]
        public string Licence { get; set; }
        [Display(Name = "Office Number")]
        public int OfficeNumber { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
        public string ProfilePicture { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public ICollection<EmployeeService> Services { get; set; }
    }
}
