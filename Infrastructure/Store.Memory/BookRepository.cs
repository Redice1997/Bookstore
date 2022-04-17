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
            throw new NotImplementedException();
        }

        public Book[] GetAllByTitleOrAuthor(string titlePart)
        {
            return books.Where(b => b.Title.Contains(titlePart)).ToArray();
        }
    }
}
