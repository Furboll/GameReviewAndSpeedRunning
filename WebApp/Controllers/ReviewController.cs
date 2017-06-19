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
        private GameReviewRunningContext _context = new GameReviewRunningContext();

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var model = await _context.Reviews.Include(r => r.Game).AsNoTracking().ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> DetailsReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.Include(r=>r.Game).SingleOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
            
        }

        public IActionResult CreateReview()
        {
            ViewData["GameId"] = new SelectList(_context.Games.ToList(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview([Bind("ReviewerName, Grade, Description, GameId")]Review review)
        {

            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Title");
            return View(review);
        }

        public async Task<IActionResult> EditReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.SingleOrDefaultAsync(r => r.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Title");
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReview(int id, [Bind("Id, ReviewerName, Grade, Description, GameId")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(review);
                        await _context.SaveChangesAsync();
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
                    ViewData["GameId"] = new SelectList(_context.Games, "Id", "Title");
                    return RedirectToAction("Index");
                }
                return View(review);
        }

        public async Task<IActionResult> DeleteReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);

            if (review == null)
            {
                return NotFound();
            }
            return View(review);
            
        }

        [HttpPost, ActionName("DeleteReview")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReviewConfirmed(int id)
        {
            var review = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }

        private bool ReviewExists(int id)
        {
            using (var context = new GameReviewRunningContext())
            {
                return context.Reviews.Any(r => r.Id == id);
            }
        }

        //private void PopulateGamesDropDownList(object selectedGame = null)
        //{
        //    var context = new GameReviewRunningContext();

        //    var gameQuery = from g in context.Games
        //                         orderby g.Title
        //                         select g;

        //    ViewBag.GameId = new SelectList(gameQuery.AsNoTracking(), "Id", "Title", selectedGame);            
        //}
    }
}
