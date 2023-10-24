﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UberEats.Models.DataLayer;

#nullable disable

namespace UberEats.Migrations
{
    [DbContext(typeof(UberEatsContext))]
    partial class UberEatsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UberEats.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Restuarent"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Grocery"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Alcohol"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Convenience"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Flower Shop"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Pet Store"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Retail"
                        });
                });

            modelBuilder.Entity("UberEats.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DLNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("UberEats.Models.MenuCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("MenuCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Appetizer"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Soup"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "Salad"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Name = "Main Course"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Name = "Dessert"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Name = "Drink"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Name = "Vegetarian"
                        });
                });

            modelBuilder.Entity("UberEats.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int?>("PartnersID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MenuCategoryId");

                    b.HasIndex("PartnersID");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("UberEats.Models.Partners", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BusinessAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusID")
                        .HasColumnType("int");

                    b.Property<int>("categoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StatusID");

                    b.HasIndex("categoryID");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("UberEats.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "New"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rejected"
                        });
                });

            modelBuilder.Entity("UberEats.Models.Driver", b =>
                {
                    b.HasOne("UberEats.Models.Status", "Status")
                        .WithMany("Drivers")
                        .HasForeignKey("StatusID");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("UberEats.Models.MenuCategory", b =>
                {
                    b.HasOne("UberEats.Models.Category", "Category")
                        .WithMany("MenuCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("UberEats.Models.MenuItem", b =>
                {
                    b.HasOne("UberEats.Models.MenuCategory", "MenuCategory")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UberEats.Models.Partners", null)
                        .WithMany("MenuItems")
                        .HasForeignKey("PartnersID");

                    b.Navigation("MenuCategory");
                });

            modelBuilder.Entity("UberEats.Models.Partners", b =>
                {
                    b.HasOne("UberEats.Models.Status", "Status")
                        .WithMany("Partners")
                        .HasForeignKey("StatusID");

                    b.HasOne("UberEats.Models.Category", "Category")
                        .WithMany("Partners")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("UberEats.Models.Category", b =>
                {
                    b.Navigation("MenuCategories");

                    b.Navigation("Partners");
                });

            modelBuilder.Entity("UberEats.Models.MenuCategory", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("UberEats.Models.Partners", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("UberEats.Models.Status", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("Partners");
                });
#pragma warning restore 612, 618
        }
    }
}
