using System.Collections.Generic;


namespace EFProjects.Models
{

    public class Author
    {
        public int ID {get; set;}

        public string Name {get; set;}

        public string DateOfBirth {get; set;}

        public ICollection<BookAuthor> BookAuthors {get; set;} 
    }



}