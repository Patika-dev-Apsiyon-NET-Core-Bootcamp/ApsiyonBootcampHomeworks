using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieAndSession.Models
{
    public class BookList
    {
        public BookList()
        {
            Books = new List<Book>()
            {
                 new Book
                {
                    Id=1,
                    Author="Author_1",
                    Name="Name_1",
                    Price=1
                },
                  new Book
                {
                    Id=2,
                    Author="Author_2",
                    Name="Name_2",
                    Price=2
                },
                  new Book
                {
                    Id=3,
                    Author="Author_3",
                    Name="Name_3",
                    Price=3
                },
                 new Book
                {
                    Id=4,
                    Author="Author_4",
                    Name="Name_4",
                    Price=4
                }
            };
        }
        public List<Book> Books { get; set; }
    }
}
