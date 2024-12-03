using EFProjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public static class SeedData
{
    public static void Initialize(AppDBContext context)
    {
        // Checks if there's any existing authors, books or bookauthors, if not, implement them.
        if (!context.Authors.Any())
        {
            context.Authors.AddRange(
                new Author { Name = "J.K. Rowling" },
                new Author { Name = "George R.R. Martin" },
                new Author { Name = "J.R.R. Tolkien" },
                new Author { Name = "E. Aladdin" }
            );
            context.SaveChanges(); // Save to generate IDs
        }

        if (!context.Books.Any())
        {
            context.Books.AddRange(
                new Book { Title = "Harry Potter and the Sorcerer's Stone", PublishedYear = "1997", Genre = "Fantasy" },
                new Book { Title = "Game of Thrones", PublishedYear = "1996", Genre = "Fantasy" },
                new Book { Title = "The Hobbit", PublishedYear = "1937", Genre = "Fantasy" },
                new Book { Title = "Aladdin and the Pupils", PublishedYear = "2024", Genre = "Educational" }
            );
            context.SaveChanges(); // Save to generate IDs
        }

        // Validate that data exists
        var authors = context.Authors.ToList();
        var books = context.Books.ToList();

        if (authors.Count == 0 || books.Count == 0)
        {
            Console.WriteLine("Authors or Books were not properly saved.");
            return;
        }

        if (!context.BookAuthors.Any())
        {
            try
            {
                context.BookAuthors.AddRange(
                    new BookAuthor { BookID = books.First(b => b.Title == "Harry Potter and the Sorcerer's Stone").ID, AuthorID = authors.First(a => a.Name == "J.K. Rowling").ID },
                    new BookAuthor { BookID = books.First(b => b.Title == "Game of Thrones").ID, AuthorID = authors.First(a => a.Name == "George R.R. Martin").ID },
                    new BookAuthor { BookID = books.First(b => b.Title == "The Hobbit").ID, AuthorID = authors.First(a => a.Name == "J.R.R. Tolkien").ID },
                    new BookAuthor { BookID = books.First(b => b.Title == "Aladdin and the Pupils").ID, AuthorID = authors.First(a => a.Name == "E. Aladdin").ID }
                );
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding BookAuthors: {ex.Message}");
            }
        }
    }



}
