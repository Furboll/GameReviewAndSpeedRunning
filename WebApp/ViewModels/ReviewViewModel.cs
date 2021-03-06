﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class ReviewViewModel
    {
        [Required]
        public string ReviewerName { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Game Game { get; set; }
    }
}
