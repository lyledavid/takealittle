using Microsoft.EntityFrameworkCore;
using Takealittle.Domain.Entities;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = 1,
                Name = "All Gold Tomato Sauce",
                Description = "6 x 700ml",
                Price = 209,
                Barcode = "123456789AAA"
            },
            new Product()
            {
                Id = 2,
                Name = "Pepsi Max",
                Description = "6 x 300ml cans",
                Price = 179,
                Barcode = "123456789AAB"
            },
            new Product()
            {
                Id = 3,
                Name = "Huggies Nappies",
                Description = "Giga Jumbo Pack",
                Price = 439,
                Barcode = "123456789AAE"
            },
            new Product()
            {
                Id = 4,
                Name = "Mrs Balls Chutney",
                Description = "1.1kg",
                Price = 69,
                Barcode = "123456789AAC"
            },
            new Product()
            {
                Id = 5,
                Name = "Weetbix Cereal",
                Description = "1.35kg",
                Price = 95,
                Barcode = "123456789AAD"
            },
            new Product()
            {
                Id = 6,
                Name = "Energade Sports Drink",
                Description = "6 x 750ml",
                Price = 179,
                Barcode = "123456789AAF"
            },
            new Product()
            {
                Id = 7,
                Name = "Black Cat Peanut Butter",
                Description = "6 x 800g",
                Price = 439,
                Barcode = "123456789AAG"
            },
            new Product()
            {
                Id = 8,
                Name = "Cooking Olive Oil",
                Description = "12 x 1L",
                Price = 1800,
                Barcode = "123456789AAH"
            },
            new Product()
            {
                Id = 9,
                Name = "Aqualle Natural Spring Water",
                Description = "4 x 5L",
                Price = 87,
                Barcode = "123456789AAI"
            },
            new Product()
            {
                Id = 10,
                Name = "Fatti's & Moni's Spaghetti",
                Description = "3kg",
                Price = 159,
                Barcode = "123456789AAJ"
            },
            new Product()
            {
                Id = 11,
                Name = "Beacon Jelly Tots",
                Description = "24 x 50g",
                Price = 299,
                Barcode = "123456789AAK"
            },
            new Product()
            {
                Id = 12,
                Name = "Crosse & Blackwell Mayonnaise",
                Description = "1.5kg",
                Price = 89,
                Barcode = "123456789AAL"
            },
            new Product()
            {
                Id = 13,
                Name = "Almonds Raw",
                Description = "1kg",
                Price = 204,
                Barcode = "123456789AAM"
            },
            new Product()
            {
                Id = 14,
                Name = "Skittles",
                Description = "14 x 38g",
                Price = 149,
                Barcode = "123456789AAN"
            },
            new Product()
            {
                Id = 15,
                Name = "ACE Super Maize Meal",
                Description = "10kg",
                Price = 189,
                Barcode = "123456789AAO"
            },
            new Product()
            {
                Id = 16,
                Name = "KOO Chakalaka",
                Description = "12 x 410g",
                Price = 269,
                Barcode = "123456789AAP"
            },
            new Product()
            {
                Id = 17,
                Name = "Aromat Refill",
                Description = "10 x 75g",
                Price = 119,
                Barcode = "123456789AAQ"
            },
            new Product()
            {
                Id = 18,
                Name = "Canned Chopped Tomatoes",
                Description = "24 x 400g",
                Price = 599,
                Barcode = "123456789AAR"
            },
            new Product()
            {
                Id = 19,
                Name = "Chickpeas in Brine",
                Description = "24 x 400g",
                Price = 269,
                Barcode = "123456789AAS"
            },
            new Product()
            {
                Id = 20,
                Name = "Oros Mango",
                Description = "24 x 300ml",
                Price = 199,
                Barcode = "123456789AAT"
            }
        );
    }
}