﻿using Bogus;
using BookShop.Entities;
using BookShop.Entitites;
using BookShop.Enums;
using System.Collections.Generic;

namespace BookShop.Seeding
{
    public static class Seeder
    {
        public static List<Author> Authors { get; set; } = null!;
        public static List<Book> Books { get; set; } = null!;
        public static List<Category> Categories { get; set; } = null!;
        public static List<BookCategory> BookCategories { get; set; } = null!;

        static Seeder()
        {
            if (Authors is null && Books is null && Categories is null && BookCategories is null)
            {
                InitializeData();
            }
        }

        private static void InitializeData()
        {
            Authors = GetAuthorGenerator().Generate(10);
            Categories = GetCategoryGenerator().Generate(10);
            Books = GetBookGenerator().Generate(10);
            BookCategories = GetBookCategoriesGenerator().Generate(5);
        }

        private static Faker<Author> GetAuthorGenerator()
        {
            return new Faker<Author>()
                .RuleFor(a => a.AuthorId, f => f.IndexFaker)
                .RuleFor(a => a.FirstName, f => f.Name.FirstName())
                .RuleFor(a => a.LastName, f => f.Name.LastName());
        }

        private static Faker<Category> GetCategoryGenerator()
        {
            return new Faker<Category>()
                .RuleFor(c => c.CategoryId, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Commerce.Department());
        }

        private static Faker<Book> GetBookGenerator()
        {
            return new Faker<Book>()
                .RuleFor(b => b.BookId, f => f.IndexFaker)
                .RuleFor(b => b.Title, f => f.Lorem.Word())
                .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
                .RuleFor(b => b.ReleaseDate, f => f.Date.Past(15))
                .RuleFor(b => b.Copies, f => f.Random.Number(1, 1000))
                .RuleFor(b => b.Price, f => f.Random.Decimal(1, 1000))
                .RuleFor(b => b.EditionType, f => f.PickRandom<EditionType>())
                .RuleFor(b => b.AgeRestriction, f => f.PickRandom<AgeRestriction>())
                .RuleFor(b => b.AuthorId, f => f.PickRandom(Authors).ID);
        }

        private static Faker<BookCategory> GetBookCategoriesGenerator()
        {
            return new Faker<BookCategory>()
                .RuleFor(bc => bc.BookId, f => f.PickRandom(Books).ID)
                .RuleFor(bc => bc.CategoryId, f => f.PickRandom(Categories).ID);
        }
    }
}
