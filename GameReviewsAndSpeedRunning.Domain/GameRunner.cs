using System;
using System.Collections.Generic;
using System.Text;

namespace GameReviewsAndSpeedRunning.Domain
{
    public class GameRunner
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int RunnerId { get; set; }
        public Runner Runner { get; set; }
    }
}
