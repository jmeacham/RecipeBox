using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeBox.ViewModel
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(255, MinimumLength = 2)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message required to send")]
        [StringLength(1024, MinimumLength = 5)]
        public string Message { get; set; }
    }
}