using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Review
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Reviewer Name")]
        public string ReviewerName { get; set; }

        [Required]
        [Range(1,10, ErrorMessage ="Value must bet between 1 and 10")]
        public int Grade { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        //[Required]
        //public List<SelectListItem> Games { get; set; }
    }
}
