using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddARecipeCategory
{
    public class DeleteModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        public DeleteModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeCategory RecipeCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeCategory = await _context.Recipes_Categories
                .Include(r => r.Category)
                .Include(r => r.Recipe).FirstOrDefaultAsync(m => m.Id == id);

            if (RecipeCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeCategory = await _context.Recipes_Categories.FindAsync(id);

            if (RecipeCategory != null)
            {
                _context.Recipes_Categories.Remove(RecipeCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
