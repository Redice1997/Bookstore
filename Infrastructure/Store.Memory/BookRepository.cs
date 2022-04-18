using System;
using System.Linq;
using Bookstore;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12557-98445", "D. Knuth", "Art Of Programming, Vol. 1", 
                    "This volume begins with basic programming concepts and techniques",
                    7.19m),
            new Book(2, "ISBN 12557-98446", "M. Fowler", "Refactoring", 
                    "As the application of object technology--particulary the Java", 
                    12.45m),
            new Book(3, "ISBN 12557-98447", "B. Kernighan, D. Ritchie", "C Programming Language", 
                    "Known as the bible of C, this classic bestseller introduces the", 
                    14.98m)
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(b => b.Author.Contains(query)
                                 || b.Title.Contains(query))
                        .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
