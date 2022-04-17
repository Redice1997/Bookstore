using System;
using System.Linq;
using Bookstore;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12557-98445", "D. Knuth", "Art Of Programming"),
            new Book(2, "ISBN 12557-98446", "M. Fowler", "Refactoring"),
            new Book(3, "ISBN 12557-98447", "B. Kernighan, D. Ritchie", "C Programming Language")
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
    }
}
