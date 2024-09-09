using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskOneDraft.Areas.Identity.Data;
using TaskOneDraft.Models;

namespace TaskOneDraft.Controllers
{
    public class ClaimsController : Controller
    {

        //Variables for db and hosting
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClaimsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        //http get 
        [HttpGet]
        public IActionResult Claims()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var claims = await _context.Claims.ToListAsync();
            return View(claims);//must match name of view file
        }

        //http post
        [HttpPost]
        public async Task<IActionResult> Claims(Claims claims)
        {
            if (ModelState.IsValid)
            {
                //Save supporting documents
                if (claims.SupportingDocuments != null && claims.SupportingDocuments.Any())
                {
                    string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    foreach (var file in claims.SupportingDocuments)
                    {
                        if (file.Length > 0)
                        {
                            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            string filePath = Path.Combine(uploadPath, fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                    }
                }
                //calc -- come back
                claims.TotalAmount = claims.HoursWorked * claims.RatePerHour;

                _context.Add(claims);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ClaimsSubmitted));//after your claim

            }
            return View(claims);
        }

        public IActionResult ClaimsSubmitted()
        {
            ViewData["Message"] = "Your claim has been submitted successfully.";
            return View("Claims");
        }
    }
}
