using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class ReviewController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            using (var context = new GameReviewRunningContext())
            {
                var model = await context.Reviews.AsNoTracking().ToListAsync();
                return View(model);
            }
        }

        public async Task<IActionResult> DetailsReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {
                var review = await context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
                if (review == null)
                {
                    return NotFound();
                }
                return View(review);
            }
        }

        public IActionResult CreateReview()
        {
                PopulateGamesDropDownList();
                return View();
        }

        private void PopulateGamesDropDownList(object selectedGame = null)
        {
            var context = new GameReviewRunningContext();
                        
            var gameQuery = from g in context.Games
                                 orderby g.Title
                                 select g;
            
            ViewBag.GameId = new SelectList(gameQuery.AsNoTracking(), "Id", "Title", selectedGame);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview([Bind("ReviewerName, Grade, Description")]Review review)
        {
            using (var context = new GameReviewRunningContext())
            {
                if (ModelState.IsValid)
                {
                    context.Reviews.Add(review);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                PopulateGamesDropDownList(review.Game);
                
            }
            return View(review);
        }

        public async Task<IActionResult> EditReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (var context = new GameReviewRunningContext())
            {
                ViewBag.Games = context.Games.ToList();

                var game = await context.Reviews.SingleOrDefaultAsync(g => g.Id == id);

                if (game == null)
                {
                    return NotFound();
                }
                return View(game);
            }
            // return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReview(int id, [Bind("Id,ReviewerName, Grade, Description, Game")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        context.Reviews.Update(review);
                        await context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ReviewExists(review.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Index");
                }
                return View(review);
            }
        }

        public async Task<IActionResult> DeleteReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {
                var review = await context.Reviews.SingleOrDefaultAsync(m => m.Id == id);

                if (review == null)
                {
                    return NotFound();
                }
                return View(review);
            }
        }

        [HttpPost, ActionName("DeleteReview")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGameConfirmed(int id)
        {
            using (var context = new GameReviewRunningContext())
            {
                var review = await context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
                context.Reviews.Remove(review);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        private bool ReviewExists(int id)
        {
            using (var context = new GameReviewRunningContext())
            {
                return context.Reviews.Any(r => r.Id == id);
            }
        }
    }
}
