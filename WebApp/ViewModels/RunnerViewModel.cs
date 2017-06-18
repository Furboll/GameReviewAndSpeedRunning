using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class RunnerViewModel
    {
        [Required]
        public string RunnerName { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
