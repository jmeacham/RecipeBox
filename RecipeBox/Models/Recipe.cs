using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
    public class Recipe
    {
       
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }

        [DataType(DataType.MultilineText)]
        public string Directions { get; set; }

        public virtual ApplicationUser User { get; set; }
                
        public string ApplicationUserId { get; set; }

        public virtual ICollection<File> Files { get; set; }

    }
}