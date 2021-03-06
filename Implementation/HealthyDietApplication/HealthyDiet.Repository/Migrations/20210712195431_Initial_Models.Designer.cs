// <auto-generated />
using System;
using HealthyDiet.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthyDiet.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210712195431_Initial_Models")]
    partial class Initial_Models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthyDiet.Domain.Domain.CommunityInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArtName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavouriteFruit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavouriteVeggie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("CommunityInfos");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Diet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Intensity")
                        .HasColumnType("float");

                    b.Property<long>("LengthDays")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("WeightLoss")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("FeedbackSum")
                        .HasColumnType("bigint");

                    b.Property<int>("MealType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NoFeedbacks")
                        .HasColumnType("bigint");

                    b.Property<string>("PictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Preparation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PreparationTime")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TimesCooked")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Statistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.Auxiliary.DayVictual", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("VictualId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("VictualId");

                    b.ToTable("DayVictuals");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.Auxiliary.FriendUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FriendId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("UserId");

                    b.ToTable("FriendUsers");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.Auxiliary.UserDiet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateFinished")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStarted")
                        .HasColumnType("datetime2");

                    b.Property<long>("DaysCompleted")
                        .HasColumnType("bigint");

                    b.Property<Guid>("DietId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Rating")
                        .HasColumnType("bigint");

                    b.Property<Guid>("StatisticsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DietId");

                    b.HasIndex("StatisticsId");

                    b.ToTable("UserDiets");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.Day", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DietId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DietId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.DayWaterIntake", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("RequiredQuantity")
                        .HasColumnType("float");

                    b.Property<Guid>("StatisticsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StatisticsId");

                    b.ToTable("DayWaterIntakes");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.FoodSample", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("StatisticsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VictualId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StatisticsId");

                    b.HasIndex("VictualId");

                    b.ToTable("FoodSamples");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.RecipeVictual", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VictualId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("VictualId");

                    b.ToTable("RecipeVictuals");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Victual", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumberCalories")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Victuals");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Identity.HealthyDietUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<long>("Age")
                        .HasColumnType("bigint");

                    b.Property<Guid>("CommunityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<long>("Height")
                        .HasColumnType("bigint");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StatisticsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.CommunityInfo", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Identity.HealthyDietUser", "User")
                        .WithOne("CommunityInfo")
                        .HasForeignKey("HealthyDiet.Domain.Domain.CommunityInfo", "UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Statistics", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Identity.HealthyDietUser", "User")
                        .WithOne("Statistics")
                        .HasForeignKey("HealthyDiet.Domain.Domain.Statistics", "UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.Auxiliary.DayVictual", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Domain.Subdomain.Day", "Day")
                        .WithMany("Victuals")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthyDiet.Domain.Domain.Victual", "Victual")
                        .WithMany("Days")
                        .HasForeignKey("VictualId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Victual");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.Auxiliary.FriendUser", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Identity.HealthyDietUser", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId");

                    b.HasOne("HealthyDiet.Domain.Identity.HealthyDietUser", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserId");

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.Auxiliary.UserDiet", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Domain.Diet", "Diet")
                        .WithMany("Diets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthyDiet.Domain.Domain.Statistics", "Statistics")
                        .WithMany("Diets")
                        .HasForeignKey("StatisticsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.Day", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Domain.Diet", "Diet")
                        .WithMany("Days")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.DayWaterIntake", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Domain.Statistics", "Statistics")
                        .WithMany("WaterIntake")
                        .HasForeignKey("StatisticsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.FoodSample", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Domain.Statistics", "Statistics")
                        .WithMany("Victuals")
                        .HasForeignKey("StatisticsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthyDiet.Domain.Domain.Victual", "Victual")
                        .WithMany("Victuals")
                        .HasForeignKey("VictualId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Statistics");

                    b.Navigation("Victual");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.RecipeVictual", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Domain.Recipe", "Recipe")
                        .WithMany("Victuals")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthyDiet.Domain.Domain.Victual", "Victual")
                        .WithMany("Recipes")
                        .HasForeignKey("VictualId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("Victual");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Identity.HealthyDietUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Identity.HealthyDietUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthyDiet.Domain.Identity.HealthyDietUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HealthyDiet.Domain.Identity.HealthyDietUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Diet", b =>
                {
                    b.Navigation("Days");

                    b.Navigation("Diets");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Recipe", b =>
                {
                    b.Navigation("Victuals");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Statistics", b =>
                {
                    b.Navigation("Diets");

                    b.Navigation("Victuals");

                    b.Navigation("WaterIntake");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Subdomain.Day", b =>
                {
                    b.Navigation("Victuals");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Domain.Victual", b =>
                {
                    b.Navigation("Days");

                    b.Navigation("Recipes");

                    b.Navigation("Victuals");
                });

            modelBuilder.Entity("HealthyDiet.Domain.Identity.HealthyDietUser", b =>
                {
                    b.Navigation("CommunityInfo");

                    b.Navigation("Friends");

                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
