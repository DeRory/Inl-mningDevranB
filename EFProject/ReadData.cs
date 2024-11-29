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
}
