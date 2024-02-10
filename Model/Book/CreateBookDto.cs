using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Validation;

namespace BookStore.Model
{
    public class CreateBookDto
    {
        [Required (ErrorMessage = "Please type title...")]
        [BanKeyword]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0, 10000000)]
        public int Amount { get; set; }
    }
}