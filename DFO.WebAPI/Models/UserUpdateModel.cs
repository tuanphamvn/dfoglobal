using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DFO.WebAPI.Models
{
    public class UserUpdateModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "User's age is required")]
        [Range(1, 120, ErrorMessage = "User's age must be between 1 and 120")]
        public int Age { get; set; }
        [MaxLength(50, ErrorMessage = "User's address must be 50 character maximum")]
        public string Address { get; set; }
    }
}
