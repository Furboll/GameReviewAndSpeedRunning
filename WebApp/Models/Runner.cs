using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Runner
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please input the nickname the Runner")]
        public string RunnerName { get; set; }

        [Required(ErrorMessage = "Please input the age of the runner")]
        public int Age { get; set; }

        public int WorldRecords { get; set; }

        public ICollection<GameRunner> GameRunner { get; set; }
        //public List<GameRunner> GameRunner { get; set; }
    }
}
