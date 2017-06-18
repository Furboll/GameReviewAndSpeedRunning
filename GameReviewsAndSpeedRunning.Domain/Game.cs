using System;
using System.Collections.Generic;

namespace GameReviewsAndSpeedRunning.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime WorldRecord { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<GameRunner> GameRunner { get; set; }
        //public List<Review> Reviews { get; set; }
        //public List<GameRunner> GameRunner { get; set; }
    }
}
