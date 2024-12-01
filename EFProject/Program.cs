using EFProjects.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using Microsoft.EntityFrameworkCore;


class Program
{
    static void Main(string[] args)
    {

        using (var context = new AppDBContext())
        {
            //Run migrations and create the database if it does not exist --- fråga aladdin om detta behövs
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
            Console.WriteLine("10. List all books by a specific author");
            Console.WriteLine("11. List all authors of a specific book");
            Console.WriteLine("12. Show loan history");
            Console.WriteLine("13. Exit");


            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddData.AddAuthor();
                    break;
                case "2":
                    AddData.AddBook();
                    break;
                case "3":
                    AddData.AddBookAuthorRelation();
                    break;
                case "4":
                    AddData.AddLoan();
                    break;
                case "5":
                    ReadData.ListBooksAndAuthors();
                    break;
                case "6":
                    ReadData.ListBorrowedBooks();
                    break;
                case "7":
                    DeleteData.DeleteAuthor();
                    break;
                case "8":
                    DeleteData.DeleteBook();
                    break;
                case "9":
                    DeleteData.DeleteLoan();
                    break;
                case "10":
                    ReadData.ListBooksByAuthor();
                    break;
                case "11":
                    ReadData.ListAuthorsByBook();
                    break;
                case "12":
                    ReadData.ShowLoanHistory();
                    break;
                case "13":
                    meny = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        }
    }
}