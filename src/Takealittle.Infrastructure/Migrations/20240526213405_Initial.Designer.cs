﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Takealittle.Infrastructure.Persistence;

#nullable disable

namespace Takealittle.Infrastructure.Migrations
{
    [DbContext(typeof(TakealittleDbContext))]
    [Migration("20240526213405_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Takealittle.Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("bit");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Takealittle.Domain.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Takealittle.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Barcode = "123456789AAA",
                            Description = "6 x 700ml",
                            Name = "All Gold Tomato Sauce",
                            Price = 209.0
                        },
                        new
                        {
                            Id = 2,
                            Barcode = "123456789AAB",
                            Description = "6 x 300ml cans",
                            Name = "Pepsi Max",
                            Price = 179.0
                        },
                        new
                        {
                            Id = 3,
                            Barcode = "123456789AAE",
                            Description = "Giga Jumbo Pack",
                            Name = "Huggies Nappies",
                            Price = 439.0
                        },
                        new
                        {
                            Id = 4,
                            Barcode = "123456789AAC",
                            Description = "1.1kg",
                            Name = "Mrs Balls Chutney",
                            Price = 69.0
                        },
                        new
                        {
                            Id = 5,
                            Barcode = "123456789AAD",
                            Description = "1.35kg",
                            Name = "Weetbix Cereal",
                            Price = 95.0
                        },
                        new
                        {
                            Id = 6,
                            Barcode = "123456789AAF",
                            Description = "6 x 750ml",
                            Name = "Energade Sports Drink",
                            Price = 179.0
                        },
                        new
                        {
                            Id = 7,
                            Barcode = "123456789AAG",
                            Description = "6 x 800g",
                            Name = "Black Cat Peanut Butter",
                            Price = 439.0
                        },
                        new
                        {
                            Id = 8,
                            Barcode = "123456789AAH",
                            Description = "12 x 1L",
                            Name = "Cooking Olive Oil",
                            Price = 1800.0
                        },
                        new
                        {
                            Id = 9,
                            Barcode = "123456789AAI",
                            Description = "4 x 5L",
                            Name = "Aqualle Natural Spring Water",
                            Price = 87.0
                        },
                        new
                        {
                            Id = 10,
                            Barcode = "123456789AAJ",
                            Description = "3kg",
                            Name = "Fatti's & Moni's Spaghetti",
                            Price = 159.0
                        },
                        new
                        {
                            Id = 11,
                            Barcode = "123456789AAK",
                            Description = "24 x 50g",
                            Name = "Beacon Jelly Tots",
                            Price = 299.0
                        },
                        new
                        {
                            Id = 12,
                            Barcode = "123456789AAL",
                            Description = "1.5kg",
                            Name = "Crosse & Blackwell Mayonnaise",
                            Price = 89.0
                        },
                        new
                        {
                            Id = 13,
                            Barcode = "123456789AAM",
                            Description = "1kg",
                            Name = "Almonds Raw",
                            Price = 204.0
                        },
                        new
                        {
                            Id = 14,
                            Barcode = "123456789AAN",
                            Description = "14 x 38g",
                            Name = "Skittles",
                            Price = 149.0
                        },
                        new
                        {
                            Id = 15,
                            Barcode = "123456789AAO",
                            Description = "10kg",
                            Name = "ACE Super Maize Meal",
                            Price = 189.0
                        },
                        new
                        {
                            Id = 16,
                            Barcode = "123456789AAP",
                            Description = "12 x 410g",
                            Name = "KOO Chakalaka",
                            Price = 269.0
                        },
                        new
                        {
                            Id = 17,
                            Barcode = "123456789AAQ",
                            Description = "10 x 75g",
                            Name = "Aromat Refill",
                            Price = 119.0
                        },
                        new
                        {
                            Id = 18,
                            Barcode = "123456789AAR",
                            Description = "24 x 400g",
                            Name = "Canned Chopped Tomatoes",
                            Price = 599.0
                        },
                        new
                        {
                            Id = 19,
                            Barcode = "123456789AAS",
                            Description = "24 x 400g",
                            Name = "Chickpeas in Brine",
                            Price = 269.0
                        },
                        new
                        {
                            Id = 20,
                            Barcode = "123456789AAT",
                            Description = "24 x 300ml",
                            Name = "Oros Mango",
                            Price = 199.0
                        });
                });

            modelBuilder.Entity("Takealittle.Domain.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Takealittle.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("Takealittle.Domain.Entities.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Takealittle.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Takealittle.Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("Takealittle.Domain.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Takealittle.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
