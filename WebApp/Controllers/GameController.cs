using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GameController : Controller
    {
        //private readonly GameReviewRunningContext _context;

        public async Task<IActionResult> Index()
        {
            using (var context = new GameReviewRunningContext())
            {
                var model = await context.Games.AsNoTracking().ToListAsync();
                return View(model);
            }
        }

        public async Task<IActionResult> DetailsGame(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {
                var game = await context.Games.SingleOrDefaultAsync(m => m.Id ==id);
                if (game == null)
                {
                    return NotFound();
                }
                return View(game);
            }
        }

        public IActionResult CreateGame()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGame([Bind("Title, Developer, ReleaseDate, WorldRecord")] Game game)
        {
            using (var context = new GameReviewRunningContext())
            {
                context.Games.Add(game);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> EditGame(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {
                var game = await context.Games.SingleOrDefaultAsync(g => g.Id ==id);
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
        public async Task<IActionResult> EditGame(int id, [Bind("Id,Title,Developer,ReleaseDate, WorldRecord")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        context.Update(game);
                        await context.SaveChangesAsync();
                    }
                    catch(DbUpdateConcurrencyException)
                    {
                        if (!GameExists(game.Id))
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
                return View(game);
            }
        }

        public async Task<IActionResult> DeleteGame(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {
                var game = await context.Games.SingleOrDefaultAsync(m => m.Id == id);

                if (game == null)
                {
                    return NotFound();
                }
                return View(game);
            }
        }

        [HttpPost, ActionName("DeleteGame")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGameConfirmed(int id)
        {
            using (var context = new GameReviewRunningContext())
            {
                var game = await context.Games.SingleOrDefaultAsync(m => m.Id ==id);
                context.Games.Remove(game);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        private bool GameExists(int id)
        {
            using (var context = new GameReviewRunningContext())
            {
                return context.Games.Any(g => g.Id == id);
            }

        }
    }
}
