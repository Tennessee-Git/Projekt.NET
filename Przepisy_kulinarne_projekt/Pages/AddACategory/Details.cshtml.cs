using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddACategory
{
    public class DetailsModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        public DetailsModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
