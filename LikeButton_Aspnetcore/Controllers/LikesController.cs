using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LikeButton_Aspnetcore.Models.DB;

namespace LikeButton_Aspnetcore.Controllers
{
    public class LikesController : Controller
    {
        private readonly LikeButtonContext _context;

        public LikesController(LikeButtonContext context)
        {
            _context = context;
        }

        // GET: Likes
        public async Task<IActionResult> Index()
        { 
            return View(await _context.Likes.FirstOrDefaultAsync(m => m.Id == 1));
        }

    
        [HttpPost]
        public async Task<IActionResult> Increment()
        {
            var likes = await _context.Likes
              .FirstOrDefaultAsync(m => m.Id == 1);


            if (ModelState.IsValid)
            {
                try
                {
                    likes.TotalLikes  = likes.TotalLikes + 1;
                    _context.Update(likes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Json("Error");
                }
                
            }
            return Json(likes.TotalLikes);
        }
        [HttpPost]
        public async Task<IActionResult> decrement()
        {
            var likes = await _context.Likes
              .FirstOrDefaultAsync(m => m.Id == 1);


            if (ModelState.IsValid)
            {
                try
                {
                    likes.TotalLikes = likes.TotalLikes - 1;
                    _context.Update(likes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Json("Error");
                }

            }
            return Json(likes.TotalLikes);
        }



        private bool LikesExists(long id)
        {
            return _context.Likes.Any(e => e.Id == id);
        }
    }
}
