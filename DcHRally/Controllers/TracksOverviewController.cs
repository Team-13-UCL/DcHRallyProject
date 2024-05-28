using DcHRally.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RallyBaneTest.Models;
using RallyBaneTest.ViewModels;

namespace DcHRally.Controllers
{
    [Authorize]
    public class TracksOverviewController : Controller
    {
        private readonly RallyDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DcHRallyIdentityDbContext _identityContext;

        public TracksOverviewController(RallyDbContext context, UserManager<ApplicationUser> userManager, DcHRallyIdentityDbContext IdentityContext)
        {
            _context = context;
            _userManager = userManager;
            _identityContext = IdentityContext;
        }

        // GET: TracksOverview
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var tracks = _context.Tracks.Where(t => t.UserId == user.Id).ToList().OrderBy(t => t.Name);
            var categories = _context.Categories.ToList();

            return View(new TrackViewModel(categories, tracks, null));
        }

        // GET: TracksOverview/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .FirstOrDefaultAsync(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }
            var categories = _context.Categories.ToList();

            return View(new TrackViewModel(categories, null, track));
        }

        // GET: TracksOverview/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .FirstOrDefaultAsync(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: TracksOverview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.TrackId == id);
        }
    }
}
