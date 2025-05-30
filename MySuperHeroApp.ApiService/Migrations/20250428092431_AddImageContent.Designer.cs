﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySuperHeroApp.ApiService.Database;

#nullable disable

namespace MySuperHeroApp.ApiService.Migrations
{
    [DbContext(typeof(SuperHeroDbContext))]
    [Migration("20250428092431_AddImageContent")]
    partial class AddImageContent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MySuperHeroApp.ApiService.Model.SuperHero", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("SuperHeroes", (string)null);
                });

            modelBuilder.Entity("MySuperHeroApp.ApiService.Model.SuperHero", b =>
                {
                    b.OwnsOne("MySuperHeroApp.ApiService.Model.Appearance", "Appearance", b1 =>
                        {
                            b1.Property<string>("SuperHeroId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("EyeColor")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EyeColor")
                                .HasAnnotation("Relational:JsonPropertyName", "eye-color");

                            b1.Property<string>("Gender")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Gender")
                                .HasAnnotation("Relational:JsonPropertyName", "gender");

                            b1.Property<string>("HairColor")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("HairColor")
                                .HasAnnotation("Relational:JsonPropertyName", "hair-color");

                            b1.Property<string>("Height")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Height")
                                .HasAnnotation("Relational:JsonPropertyName", "height");

                            b1.Property<string>("Race")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Race")
                                .HasAnnotation("Relational:JsonPropertyName", "race");

                            b1.Property<string>("Weight")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Weight")
                                .HasAnnotation("Relational:JsonPropertyName", "weight");

                            b1.HasKey("SuperHeroId");

                            b1.ToTable("SuperHeroes");

                            b1.HasAnnotation("Relational:JsonPropertyName", "appearance");

                            b1.WithOwner()
                                .HasForeignKey("SuperHeroId");
                        });

                    b.OwnsOne("MySuperHeroApp.ApiService.Model.Biography", "Biography", b1 =>
                        {
                            b1.Property<string>("SuperHeroId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Aliases")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Aliases")
                                .HasAnnotation("Relational:JsonPropertyName", "aliases");

                            b1.Property<string>("Alignment")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Alignment")
                                .HasAnnotation("Relational:JsonPropertyName", "alignment");

                            b1.Property<string>("AlterEgos")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AlterEgos")
                                .HasAnnotation("Relational:JsonPropertyName", "alter-egos");

                            b1.Property<string>("FirstAppearance")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstAppearance")
                                .HasAnnotation("Relational:JsonPropertyName", "first-appearance");

                            b1.Property<string>("FullName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FullName")
                                .HasAnnotation("Relational:JsonPropertyName", "full-name");

                            b1.Property<string>("PlaceOfBirth")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PlaceOfBirth")
                                .HasAnnotation("Relational:JsonPropertyName", "place-of-birth");

                            b1.Property<string>("Publisher")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Publisher")
                                .HasAnnotation("Relational:JsonPropertyName", "publisher");

                            b1.HasKey("SuperHeroId");

                            b1.ToTable("SuperHeroes");

                            b1.HasAnnotation("Relational:JsonPropertyName", "biography");

                            b1.WithOwner()
                                .HasForeignKey("SuperHeroId");
                        });

                    b.OwnsOne("MySuperHeroApp.ApiService.Model.Connections", "Connections", b1 =>
                        {
                            b1.Property<string>("SuperHeroId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("GroupAffiliation")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("GroupAffiliation")
                                .HasAnnotation("Relational:JsonPropertyName", "group-affiliation");

                            b1.Property<string>("Relatives")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Relatives")
                                .HasAnnotation("Relational:JsonPropertyName", "relatives");

                            b1.HasKey("SuperHeroId");

                            b1.ToTable("SuperHeroes");

                            b1.HasAnnotation("Relational:JsonPropertyName", "connections");

                            b1.WithOwner()
                                .HasForeignKey("SuperHeroId");
                        });

                    b.OwnsOne("MySuperHeroApp.ApiService.Model.Image", "Image", b1 =>
                        {
                            b1.Property<string>("SuperHeroId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("ImageContent")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ImageContent");

                            b1.Property<string>("Url")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ImageUrl")
                                .HasAnnotation("Relational:JsonPropertyName", "url");

                            b1.HasKey("SuperHeroId");

                            b1.ToTable("SuperHeroes");

                            b1.HasAnnotation("Relational:JsonPropertyName", "image");

                            b1.WithOwner()
                                .HasForeignKey("SuperHeroId");
                        });

                    b.OwnsOne("MySuperHeroApp.ApiService.Model.PowerStats", "PowerStats", b1 =>
                        {
                            b1.Property<string>("SuperHeroId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Combat")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Combat")
                                .HasAnnotation("Relational:JsonPropertyName", "combat");

                            b1.Property<string>("Durability")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Durability")
                                .HasAnnotation("Relational:JsonPropertyName", "durability");

                            b1.Property<string>("Intelligence")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Intelligence")
                                .HasAnnotation("Relational:JsonPropertyName", "intelligence");

                            b1.Property<string>("Power")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Power")
                                .HasAnnotation("Relational:JsonPropertyName", "power");

                            b1.Property<string>("Speed")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Speed")
                                .HasAnnotation("Relational:JsonPropertyName", "speed");

                            b1.Property<string>("Strength")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Strength")
                                .HasAnnotation("Relational:JsonPropertyName", "strength");

                            b1.HasKey("SuperHeroId");

                            b1.ToTable("SuperHeroes");

                            b1.HasAnnotation("Relational:JsonPropertyName", "powerstats");

                            b1.WithOwner()
                                .HasForeignKey("SuperHeroId");
                        });

                    b.OwnsOne("MySuperHeroApp.ApiService.Model.Work", "Work", b1 =>
                        {
                            b1.Property<string>("SuperHeroId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("BaseOfOperation")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("BaseOfOperation")
                                .HasAnnotation("Relational:JsonPropertyName", "base");

                            b1.Property<string>("Occupation")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Occupation")
                                .HasAnnotation("Relational:JsonPropertyName", "occupation");

                            b1.HasKey("SuperHeroId");

                            b1.ToTable("SuperHeroes");

                            b1.HasAnnotation("Relational:JsonPropertyName", "work");

                            b1.WithOwner()
                                .HasForeignKey("SuperHeroId");
                        });

                    b.Navigation("Appearance")
                        .IsRequired();

                    b.Navigation("Biography")
                        .IsRequired();

                    b.Navigation("Connections")
                        .IsRequired();

                    b.Navigation("Image")
                        .IsRequired();

                    b.Navigation("PowerStats")
                        .IsRequired();

                    b.Navigation("Work")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
