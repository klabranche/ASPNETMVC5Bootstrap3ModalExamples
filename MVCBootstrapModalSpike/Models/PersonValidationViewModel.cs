using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBootstrapModalSpike.Models
{
    public class PersonValidationViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25,MinimumLength=3,ErrorMessage="First Name is too short or too long.")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Last Name is too short or too long.")]
        [Display(Name = "First Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)] 
        public DateTime BirthDate { get; set; }
    }
}