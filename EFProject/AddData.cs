using System;
using System.Linq;
using EFProjects.Models;
using Microsoft.EntityFrameworkCore;

public class AddData
{
    // Adding author method
    public static void AddAuthor()
    {
        using (var context = new AppDBContext())
        {
            System.Console.WriteLine("Enter author name: ");
            string authorName = Console.ReadLine();

            var author = new Author
            {
                Name = authorName

            };

            context.Authors.Add(author);
            context.SaveChanges();

            System.Console.WriteLine($"Great! Author '{authorName}' has been added!");
        }
    }

    //Adding book method
    public static void AddBook()
    {
        using (var context = new AppDBContext())
        {
            Console.WriteLine("Enter book title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter published year of the book: ");
            string publishedYear = Console.ReadLine();

            Console.WriteLine("Enter the genre of the book: ");
            string genre = Console.ReadLine();

            var book = new Book
            {
                Title = title,
                PublishedYear = publishedYear,
                Genre = genre
            };

            context.Books.Add(book); //Adding the book into the database
            context.SaveChanges(); //Save the changes in the database

            System.Console.WriteLine($"Book '{title}' with published year and genre: {publishedYear}, {genre} has been added into the database");
        }
    }

    public static void AddBookAuthorRelation()
    {
        using (var context = new AppDBContext())
        {

            System.Console.WriteLine("Enter the book ID to associate it with an author of your choice: ");
            int bookID = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter author ID to associate it with the book");
            int authorID = int.Parse(Console.ReadLine());

            var book = context.Books.Find(bookID); //Finds the book
            var author = context.Authors.Find(authorID); //Finds the author

            if (book != null && author != null)
            {
                var bookAuthor = new BookAuthor
                {
                    BookID = bookID,
                    AuthorID = authorID
                };

                context.BookAuthors.Add(bookAuthor); //Adds the relation between book and author into the database
                context.SaveChanges();

                System.Console.WriteLine($"Great! The book '{book.Title}' has been associated with Author '{author.Name}'.");
            }
            else
            {
                System.Console.WriteLine("Either the book or author was not found");
            }

        }

    }

    // Add loan method
    public static void AddLoan()
    {
        using (var context = new AppDBContext())
        {
            System.Console.WriteLine("Enter book ID to loan the book");
            int bookID = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter borrower name: ");
            string borrower = Console.ReadLine();

            var book = context.Books.Find(bookID);

            if (book != null)
            {
                var loan = new Loan
                {
                    BookID = bookID,
                    BorrowerName = borrower,
                    LoanDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(30)
                };

                context.Loans.Add(loan);
                context.SaveChanges();

                System.Console.WriteLine($"Loan added for book '{book.Title}' to borrower '{borrower}!");
            }
            else
            {
                System.Console.WriteLine("Book not found!");
            }
        }
    }
}