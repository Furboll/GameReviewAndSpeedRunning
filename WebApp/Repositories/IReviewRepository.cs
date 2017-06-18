using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    interface IReviewRepository
    {
        void AddReview(Game game);

        void EditReview(Review review);

        void DeleteReview(Review review);

        Review GetReviewId(int reviewId);
    }
}
