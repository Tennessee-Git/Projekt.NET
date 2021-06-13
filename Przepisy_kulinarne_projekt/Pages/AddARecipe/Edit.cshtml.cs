using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddARecipe
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty(SupportsGet = true)]
        public Recipe Recipe { get; set; }
        [BindProperty]
        public IFormFile Picture { get; set; }
        [BindProperty]
        public Photography Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Recipe.Date = DateTime.Now;
            if (Picture != null)
            {
                string uniqueFileName = UploadFile();
                Photo.Path = uniqueFileName;
            }
            Photo.Recipe = Recipe;
            Photo.RecipeId = Recipe.Id;

            _context.Attach(Recipe).State = EntityState.Modified;
            _context.PhotoGallery.Add(Photo);
            
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(Recipe.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }

        private string UploadFile()
        {
            string uniqueFileName = null;
            if(Picture!=null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Picture.FileName;
                string filePath = Path.Combine("wwwroot/images/", uniqueFileName);
                using (var fileStream = new FileStream(filePath,FileMode.Create))
                {
                    Picture.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
