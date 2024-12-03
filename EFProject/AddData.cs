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

            Console.WriteLine("Available Books:");
            foreach (var listedBook in context.Books.ToList())
            {
                Console.WriteLine($"ID: {listedBook.ID}, Title: {listedBook.Title}, Published Year: {listedBook.PublishedYear}, Genre: {listedBook.Genre}");
            }

            Console.WriteLine("\nAvailable Authors:");
            foreach (var listedAuthor in context.Authors.ToList())
            {
                Console.WriteLine($"ID: {listedAuthor.ID}, Name: {listedAuthor.Name}");
            }


            Console.WriteLine("\nEnter the Book ID to associate it with an Author of your choice: ");
            if (!int.TryParse(Console.ReadLine(), out int bookID))
            {
                Console.WriteLine("Invalid Book ID. Please enter a number.");
                return;
            }


            Console.WriteLine("Enter Author ID to associate it with the Book: ");
            if (!int.TryParse(Console.ReadLine(), out int authorID))
            {
                Console.WriteLine("Invalid Author ID. Please enter a number.");
                return;
            }

            // finds the book and author in the database via the Find method
            var book = context.Books.Find(bookID);
            var author = context.Authors.Find(authorID);

            if (book != null && author != null)
            {
                var bookAuthor = new BookAuthor
                {
                    BookID = bookID,
                    AuthorID = authorID
                };

                context.BookAuthors.Add(bookAuthor);
                context.SaveChanges();

                Console.WriteLine($"\nGreat! The book '{book.Title}' has been associated with Author '{author.Name}'.");
            }
            else
            {
                Console.WriteLine("\nEither the book or author was not found. Please verify the IDs and try again.");
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