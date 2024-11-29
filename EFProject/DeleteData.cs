using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EFProjects.Models; 

public class DeleteData
{
    public static void DeleteAuthor()
    {
        using (var context = new AppDBContext())
        {
            Console.WriteLine("Enter author ID to delete:");
            int authorId = int.Parse(Console.ReadLine());

            var author = context.Authors.Find(authorId);
            if (author != null)
            {
                context.Authors.Remove(author); 
                context.SaveChanges();  
                Console.WriteLine($"Author '{author.Name}' has been deleted.");
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }
    }

    public static void DeleteBook()
    {
        using (var context = new AppDBContext())
        {
            Console.WriteLine("Enter book ID to delete:");
            int bookId = int.Parse(Console.ReadLine());

            var book = context.Books.Find(bookId);
            if (book != null)
            {
                context.Books.Remove(book); 
                context.SaveChanges();  
                Console.WriteLine($"Book '{book.Title}' has been deleted.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    public static void DeleteLoan()
    {
        using (var context = new AppDBContext())
        {
            Console.WriteLine("Enter loan ID to delete:");
            int loanId = int.Parse(Console.ReadLine());

            var loan = context.Loans.Find(loanId);
            if (loan != null)
            {
                context.Loans.Remove(loan);  
                context.SaveChanges();  
                Console.WriteLine($"Loan with ID '{loanId}' has been deleted.");
            }
            else
            {
                Console.WriteLine("Loan not found.");
            }
        }
    }
}