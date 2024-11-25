using System.Collections.Generic;


namespace EFProjects.Models
{
    public class Loan
    {
        public int ID {get; set;}
        public int BookID {get; set;} //Foreign nyckel to Book

        public Book? Book {get; set;}




        public DateTime LoanDate {get; set;}

        public DateTime ReturnDate {get; set;}

        public string BorrowerName {get; set;}

        public string SocialNumber {get; set;}



    }





}