using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TinyTotsWebApp.Models
{
    public class TinyTots
    {
        [Key]
        public int RegistrationId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public string Gender { get; set; }
        public string FoodAllergires { get; set; }
    }
}