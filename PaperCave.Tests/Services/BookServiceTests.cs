using NSubstitute;
using PaperCave.Core.Services;
using PaperCave.DTO.Book;
using PaperCave.Infrastructure.Repository.Books;

namespace PaperCave.Tests.Services
{
    public class BookServiceTests
    {
        [Fact]
        public async Task GetAllBooks_ReturnsBooks_FromRepository()
        {
            // Arrange
            var repo = Substitute.For<IBookRepository>();
            var expected = new List<BookDTO>
            {
                new BookDTO { Id = 1, Title = "One", Author = "A", GenreId = "G1", PageCount = 100 },
                new BookDTO { Id = 2, Title = "Two", Author = "B", GenreId = "G2", PageCount = 200 }
            };

            repo.GetAllBooks(Arg.Any<int>(), Arg.Any<int>())
                .Returns(Task.FromResult((IEnumerable<BookDTO>)expected));

            var service = new BookService(repo);

            // Act
            var result = (await service.GetAllBooks(2, 0)).ToList();

            // Assert
            Assert.Equal(expected.Count, result.Count);
            Assert.Equal(expected.Select(b => b.Id), result.Select(b => b.Id));
            await repo.Received(1).GetAllBooks(2, 0);
        }

        [Fact]
        public async Task GetBookByTitle_ReturnsBook_FromRepository()
        {
            // Arrange
            var repo = Substitute.For<IBookRepository>();
            var expected = new BookDTO { Id = 10, Title = "My Book", Author = "Author", GenreId = "G", PageCount = 123 };

            repo.GetBookByTitle("My Book").Returns(Task.FromResult(expected));

            var service = new BookService(repo);

            // Act
            var result = await service.GetBookByTitle("My Book");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.Title, result.Title);
            await repo.Received(1).GetBookByTitle("My Book");
        }
    }
}
