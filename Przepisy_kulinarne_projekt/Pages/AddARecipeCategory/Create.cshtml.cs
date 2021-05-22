using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddARecipeCategory
{
    public class CreateModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        public CreateModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "RecipeName");
            return Page();
        }

        [BindProperty]
        public RecipeCategory RecipeCategory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipes_Categories.Add(RecipeCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
