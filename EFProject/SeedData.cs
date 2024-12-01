using EFProjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public static class SeedData
{
    public static void Initialize(AppDBContext context)
    {
        // Checks if theres any existing authors, books or bookauthors, if not, implement them.
        if (!context.Authors.Any())
        {
            // Adds authors
            context.Authors.AddRange(
                new Author { Name = "J.K. Rowling" },
                new Author { Name = "George R.R. Martin" },
                new Author { Name = "J.R.R. Tolkien" },
                new Author { Name = "E. Aladdin" }
                
            );
        }

        if (!context.Books.Any())
        {
            // Adds books
            context.Books.AddRange(
                new Book { Title = "Harry Potter and the Sorcerer's Stone", PublishedYear = "1997", Genre = "Fantasy" },
                new Book { Title = "Game of Thrones", PublishedYear = "1996", Genre = "Fantasy" },
                new Book { Title = "The Hobbit", PublishedYear = "1937", Genre = "Fantasy" },
                new Book { Title = "Aladdin and the pupils", PublishedYear = "2024", Genre = "Educational"},
                new Book { Title = "The Holy Trinity", PublishedYear = "1999", Genre = "Fantasy"}

            );
        }

        if (!context.BookAuthors.Any())
        {
            // Adds bookauthors relation
            context.BookAuthors.AddRange(
                new BookAuthor { BookID = 1, AuthorID = 1 },
                new BookAuthor { BookID = 2, AuthorID = 2 },
                new BookAuthor { BookID = 3, AuthorID = 3 },
                new BookAuthor { BookID = 4, AuthorID = 4 },
                new BookAuthor { BookID = 5, AuthorID = 2 },
                new BookAuthor { BookID = 5, AuthorID = 3 },
                new BookAuthor { BookID = 5, AuthorID = 4 }
            );
        }
        context.SaveChanges();
    }
}
