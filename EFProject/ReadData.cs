using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using EFProjects.Models;

public class ReadData
{
    public static void ListBooksAndAuthors()
    {
        using (var context = new AppDBContext())
        {
            var books = context.Books
                .Include(b => b.BookAuthors) // include relation to bookauhtor
                .ThenInclude(ba => ba.Author) // include author in bookauthor
                .ToList();

            if (books.Any())
            {
                Console.WriteLine("Books and their authors:");
                foreach (var book in books)
                {
                    Console.WriteLine($"Book: {book.Title}");
                    foreach (var bookAuthor in book.BookAuthors)
                    {
                        Console.WriteLine($"  Author: {bookAuthor.Author.Name}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No books or authors found in the database.");
            }
        }
    }




    public static void ListBorrowedBooks()
    {
        using (var context = new AppDBContext())
        {
            var loans = context.Loans
                .Include(l => l.Book) // include relation to bookauthor
                .ToList();

            if (loans.Any())
            {
                Console.WriteLine("Borrowed books and their return dates:");
                foreach (var loan in loans)
                {
                    var returnDate = loan.LoanDate.AddDays(30);
                    Console.WriteLine($"Book: {loan.Book.Title}, Borrower: {loan.BorrowerName}, Return Date: {returnDate.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No borrowed books found in the database.");
            }
        }
    }

    public static void ListBooksByAuthor()
    {
        using (var context = new AppDBContext())
        {
            System.Console.WriteLine("Enter Author ID to list their books: ");
            int authorId = int.Parse(Console.ReadLine());

            var author = context.Authors
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .FirstOrDefault(a => a.ID == authorId);

            if (author != null)
            {
                Console.WriteLine($"Books written by {author.Name}:");
                foreach (var bookAuthor in author.BookAuthors)
                {
                    Console.WriteLine($"- {bookAuthor.Book.Title}");
                }
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }
    }

    public static void ListAuthorsByBook()
    {
        using (var context = new AppDBContext())
        {
            Console.WriteLine("Enter Book ID to list its authors: ");
            int bookId = int.Parse(Console.ReadLine());

            var book = context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .FirstOrDefault(b => b.ID == bookId);

            if (book != null)
            {
                Console.WriteLine($"Authors who contributed to {book.Title}:");
                foreach (var bookAuthor in book.BookAuthors)
                {
                    Console.WriteLine($"- {bookAuthor.Author.Name}");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    public static void ShowLoanHistory()
    {
        using (var context = new AppDBContext())
        {
            var loans = context.Loans
                .Include(l => l.Book)
                .ToList();

            if (loans.Any())
            {
                Console.WriteLine("Loan History:");
                foreach (var loan in loans)
                {
                    var returnDate = loan.LoanDate.AddDays(30); // Loantime is 30 days
                    Console.WriteLine($"Book: {loan.Book.Title}, Borrower: {loan.BorrowerName}, Loan Date: {loan.LoanDate.ToShortDateString()}, Return Date: {returnDate.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No loans found in the database.");
            }
        }
    }
}
