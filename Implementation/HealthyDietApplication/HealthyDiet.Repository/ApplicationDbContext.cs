using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyDiet.Repository
{
    public class ApplicationDbContext : IdentityDbContext<HealthyDietUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DayWaterIntake> DayWaterIntakes { get; set; }
        public virtual DbSet<FoodSample> FoodSamples { get; set; }
        public virtual DbSet<RecipeVictual> RecipeVictuals { get; set; }
        public virtual DbSet<DayVictual> DayVictuals { get; set; }
        public virtual DbSet<UserDiet> UserDiets { get; set; }

        public virtual DbSet<CommunityInfo> CommunityInfos { get; set; }
        public virtual DbSet<Statistics> Statistics { get; set; }

        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Diet> Diets { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Victual> Victuals { get; set; }

        public virtual DbSet<FriendUser> FriendUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);

            // IDENTIFIERS

            // Auxiliary

            builder.Entity<DayWaterIntake>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<FoodSample>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<RecipeVictual>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<FriendUser>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<UserDiet>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<DayVictual>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            // Subdomain

            builder.Entity<CommunityInfo>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Statistics>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            // Domain

            builder.Entity<Day>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Diet>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Recipe>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Victual>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            // RELATIONS

            // User relations

            builder.Entity<HealthyDietUser>()
                .HasOne(z => z.Statistics)
                .WithOne(t => t.User)
                .HasForeignKey<Statistics>(t => t.UserId);

            builder.Entity<HealthyDietUser>()
                .HasOne(z => z.CommunityInfo)
                .WithOne(z => z.User)
                .HasForeignKey<CommunityInfo>(t => t.UserId);

            // friend relation

            builder.Entity<HealthyDietUser>()
                .HasMany(z => z.Friends)
                .WithOne(z => z.User)
                .HasForeignKey(t => t.UserId);

            // OTHER RELATIONS

            builder.Entity<Statistics>()
                .HasMany(z => z.WaterIntake)
                .WithOne(z => z.Statistics)
                .HasForeignKey(t => t.StatisticsId);

            builder.Entity<UserDiet>()
                .HasOne(z => z.Statistics)
                .WithMany(z => z.Diets)
                .HasForeignKey(t => t.StatisticsId);

            builder.Entity<UserDiet>()
                .HasOne(z => z.Diet)
                .WithMany(z => z.Diets)
                .HasForeignKey(t => t.DietId);

            builder.Entity<Diet>()
                .HasMany(z => z.Days)
                .WithOne(z => z.Diet)
                .HasForeignKey(t => t.DietId);

            builder.Entity<DayVictual>()
                .HasOne(z => z.Day)
                .WithMany(z => z.Victuals)
                .HasForeignKey(t => t.DayId);

            builder.Entity<DayVictual>()
                .HasOne(z => z.Victual)
                .WithMany(z => z.Days)
                .HasForeignKey(t => t.VictualId);

            builder.Entity<FoodSample>()
                .HasOne(z => z.Statistics)
                .WithMany(z => z.Victuals)
                .HasForeignKey(t => t.StatisticsId);

            builder.Entity<FoodSample>()
                .HasOne(z => z.Victual)
                .WithMany(z => z.Victuals)
                .HasForeignKey(t => t.VictualId);

            builder.Entity<RecipeVictual>()
                .HasOne(z => z.Victual)
                .WithMany(z => z.Recipes)
                .HasForeignKey(t => t.VictualId);

            builder.Entity<RecipeVictual>()
                .HasOne(z => z.Recipe)
                .WithMany(z => z.Victuals)
                .HasForeignKey(t => t.RecipeId);
            
        }
    }
}
