using System;
using System.Collections.Generic;
using System.Text;

namespace GameReviewsAndSpeedRunning.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public int Grade { get; set; }
        public string Description { get; set; }
        public Game Game { get; set; }
    }
}
