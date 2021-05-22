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
    public class IndexModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        public IndexModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
