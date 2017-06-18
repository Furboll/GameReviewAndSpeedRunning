using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime WorldRecord { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<GameRunner> GameRunner { get; set; }
        //public List<Review> Reviews { get; set; }
        //public List<GameRunner> GameRunner { get; set; }
    }
}
