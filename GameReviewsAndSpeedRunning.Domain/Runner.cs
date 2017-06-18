using System;
using System.Collections.Generic;
using System.Text;

namespace GameReviewsAndSpeedRunning.Domain
{
    public class Runner
    {
        public int Id { get; set; }
        public string RunnerName { get; set; }
        public int Age { get; set; }

        public ICollection<GameRunner> GameRunner { get; set; }
        //public List<GameRunner> GameRunner { get; set; }
    }
}
