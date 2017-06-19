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
    public class RunnerController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            using (var context = new GameReviewRunningContext())
            {
                var model = await context.Runners.AsNoTracking().ToListAsync();
                return View(model);
            }

        }

        public async Task<IActionResult> DetailsRunner(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {
                var runner = await context.Runners.SingleOrDefaultAsync(m => m.Id == id);
                if (runner == null)
                {
                    return NotFound();
                }
                return View(runner);
            }
        }

        public IActionResult CreateRunner()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRunner([Bind("RunnerName, Age, WorldRecords")]Runner runner)
        {
            using (var context = new GameReviewRunningContext())
            {
                if (ModelState.IsValid)
                {
                    context.Add(runner);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View();
            }
        }

        public async Task<IActionResult> EditRunner(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (var context = new GameReviewRunningContext())
            {
                ViewBag.Games = context.Games.ToList();

                var runner = await context.Runners.SingleOrDefaultAsync(g => g.Id == id);

                if (runner == null)
                {
                    return NotFound();
                }
                return View(runner);
            }
            // return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRunner(int id, [Bind("Id, RunnerName, Age, WorldRecords")]Runner runner)
        {
            if (id != runner.Id)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        context.Runners.Update(runner);
                        await context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RunnerExists(runner.Id))
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
                return View(runner);
            }
        }

        private bool RunnerExists(int id)
        {
            using (var context = new GameReviewRunningContext())
            {
                return context.Runners.Any(r => r.Id == id);
            }
        }

        public async Task<IActionResult> DeleteRunner(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var context = new GameReviewRunningContext())
            {
                var runner = await context.Runners.SingleOrDefaultAsync(m => m.Id == id);

                if (runner == null)
                {
                    return NotFound();
                }
                return View(runner);
            }
        }

        [HttpPost, ActionName("DeleteRunner")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRunnerConfirmed(int id)
        {
            using (var context = new GameReviewRunningContext())
            {
                var runner = await context.Runners.SingleOrDefaultAsync(m => m.Id == id);
                context.Runners.Remove(runner);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

    }
}
