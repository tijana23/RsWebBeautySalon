using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautySalonT.Models;

namespace BeautySalonT.ViewModels
{
    public class EmployeeServiceViewModel
    {
        public IList<Employee> Employees { get; set; }

        public SelectList Services { get; set; }


    }
}
