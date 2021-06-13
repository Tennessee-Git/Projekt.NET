using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Przepisy_kulinarne_projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;
        public List<Recipe> Recipes { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Recipes = _context.Recipes.OrderByDescending(d => d.Rating).Take(10).ToList<Recipe>();
        }
    }
}
