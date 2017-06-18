using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Game
    {
        //[Required]
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is requiered")]
        public string Title { get; set; }

        [Display(Name = "Developer of the Game")]
        [Required(ErrorMessage = "Developer is requiered")]
        public string Developer { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Date is Requiered")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "World record (ex. 2h 34m 16s)")]
        public string WorldRecord { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<GameRunner> GameRunner { get; set; }
    }
}
