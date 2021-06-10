using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Przepisy_kulinarne_projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(b => b.Recipe)
                .WithMany(ba => ba.RecipeCategories)
                .HasForeignKey(bi => bi.RecipeId);

            modelBuilder.Entity<RecipeCategory>()
              .HasOne(b => b.Category)
              .WithMany(ba => ba.RecipeCategories)
              .HasForeignKey(bi => bi.CategoryId);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<FavouriteRecipe> FavouriteRecipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<Photography> PhotoGallery { get; set; }
    }
}
