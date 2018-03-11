using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTHeadBrewery.Models
{
    public class Brewed
    {
        public int BrewedID { get; set; }
        public int EmployeeID { get; set; }
        public int BeerID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Beer Beer { get; set; }
    }
}