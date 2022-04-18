using Bookstore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests
{
    public class SearchServiceTests
    {
        //[Fact]
        //public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        //{
        //    var bookRepositoryStub = new Mock<IBookRepository>();
        //    bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
        //                      .Returns(new[] { new Book(1, "", "", "") });

        //    bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
        //                      .Returns(new[] { new Book(2, "", "", "") });

        //    var searchService = new SearchService(bookRepositoryStub.Object);
        //    var validIsbn = "ISBN 12356-65472";

        //    var actual = searchService.GetAllByQuery(validIsbn);

        //    Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        //}
        //[Fact]
        //public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        //{
        //    var bookRepositoryStub = new Mock<IBookRepository>();
        //    bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
        //                      .Returns(new[] { new Book(1, "", "", "") });

        //    bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
        //                      .Returns(new[] { new Book(2, "", "", "") });

        //    var searchService = new SearchService(bookRepositoryStub.Object);
        //    var invalidIsbn = "12356-65472";

        //    var actual = searchService.GetAllByQuery(invalidIsbn);

        //    Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        //}

        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;
            var bookRepository = new StubBookRepository();

            bookRepository.ResultOfGetAllByIsbn = new[]
            {
                new Book(idOfIsbnSearch, "", "", "", "", 0m)
            };
            bookRepository.ResultOfGetAllByTitleOrAuthor = new[]
            {
                new Book(idOfAuthorSearch, "", "", "", "", 0m)
            };

            var searchService = new SearchService(bookRepository);

            var books = searchService.GetAllByQuery("ISBN 12345-67890");

            Assert.Collection(books, (book) => Assert.Equal(idOfIsbnSearch, book.Id));
        }
        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;
            var bookRepository = new StubBookRepository();

            bookRepository.ResultOfGetAllByIsbn = new[]
            {
                new Book(idOfIsbnSearch, "", "", "", "", 0m)
            };
            bookRepository.ResultOfGetAllByTitleOrAuthor = new[]
            {
                new Book(idOfAuthorSearch, "", "", "", "", 0m)
            };

            var searchService = new SearchService(bookRepository);

            var books = searchService.GetAllByQuery("12345-67890");

            Assert.Collection(books, book => Assert.Equal(idOfAuthorSearch, book.Id));
        }
    }
}
