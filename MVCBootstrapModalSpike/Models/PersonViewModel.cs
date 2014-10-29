using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBootstrapModalSpike.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}