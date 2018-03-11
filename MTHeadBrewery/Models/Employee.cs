using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTHeadBrewery.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
        public DateTime StartDate { get; set; }
        public string EmpBio { get; set; }

        public virtual ICollection<Brewed> Brewing { get; set; }
    }
}