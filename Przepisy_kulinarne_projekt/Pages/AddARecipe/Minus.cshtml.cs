using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Przepisy_kulinarne_projekt.Models;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Data;

namespace Przepisy_kulinarne_projekt.Pages.AddARecipe
{
    public class MinusModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        public MinusModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnPost(int? id)
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

            Recipe.Rating--;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
