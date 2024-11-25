using System.Collections.Generic;


namespace EFProjects.Models
{
    public class Book
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string PublishedYear { get; set; }

        public string Genre { get; set; }

        public ICollection<BookAuthor> BookAuthors {get; set;} = new List<BookAuthor>();

        public ICollection<Loan> Loans {get; set;} = new List<Loan>();

    }

}