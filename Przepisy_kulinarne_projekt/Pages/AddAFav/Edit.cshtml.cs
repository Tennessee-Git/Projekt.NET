using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddAFav
{
    public class EditModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        public EditModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FavRecipePerson FavRecipePerson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FavRecipePerson = await _context.FavRecipes
                .Include(f => f.Person)
                .Include(f => f.Recipe).FirstOrDefaultAsync(m => m.Id == id);

            if (FavRecipePerson == null)
            {
                return NotFound();
            }
           ViewData["PersonId"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Ingredients");
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

            _context.Attach(FavRecipePerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavRecipePersonExists(FavRecipePerson.Id))
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

        private bool FavRecipePersonExists(int id)
        {
            return _context.FavRecipes.Any(e => e.Id == id);
        }
    }
}
