using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class SignUpDto
    {
        [Required]
        public string FirstName {get; set;}
        [Required]
        public string LastName {get; set;}
        [Required, EmailAddress]
        public string Email {get; set;}
        [Required]
        public string Password {get; set;}
        [Required, Compare(nameof(Password))]
        public string ConfirmPassword {get; set;}
    }
}