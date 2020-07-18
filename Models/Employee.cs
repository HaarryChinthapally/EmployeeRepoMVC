using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeRepoMVC.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String EmailID { get; set; }
    }
}