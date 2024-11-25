using System.Collections.Generic;


namespace EFProjects.Models
{
    public class BookAuthor
    {
        public int BookID {get; set;} //Foreign key to book
        public Book? Book {get; set;} 


        public int AuthorID {get; set;} //Foreign key to Author

         public Author? Author {get; set;}





    }










}