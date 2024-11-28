using EFProjects.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;


class Program
{
    static void Main(string[] args)
    {

        using (var context = new AppDBContext())
        {
            //Run migrations and create the database if it does not exist
            context.Database.Migrate();

            //The seed data when initiating the database
            SeedData.Initialize(context);
        }


        bool meny = false;
        while (!meny)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Author");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Add Book-Author Relation");
            Console.WriteLine("4. Add Loan");
            Console.WriteLine("5. List Books and Their Authors");
            Console.WriteLine("6. List Borrowed Books and Their Return Dates");
            Console.WriteLine("7. Delete Author");
            Console.WriteLine("8. Delete Book");
            Console.WriteLine("9. Delete Loan");
            Console.WriteLine("10. Exit");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddData.AddAuthor();  // Add author
                    break;
                case "2":
                    AddData.AddBook();  // Add book
                    break;
                case "3":
                    AddData.AddBookAuthorRelation();  // Add relation between book and author
                    break;
                case "4":
                    AddData.AddLoan();  // Add loan
                    break;
                case "5":
                    // List books and their authors
                    ReadData.ListBooksAndAuthors();
                    break;
                case "6":
                    // List borrowed books and their return dates
                    ReadData.ListBorrowedBooks();
                    break;
                case "7":
                    // Delete author
                    DeleteData.DeleteAuthor();
                    break;
                case "8":
                    // Delete book
                    DeleteData.DeleteBook();
                    break;
                case "9":
                    // Delete loan
                    DeleteData.DeleteLoan();
                    break;
                case "10":
                    meny = true;  // Ends the programme
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}