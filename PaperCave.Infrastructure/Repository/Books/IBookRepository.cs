using PaperCave.DTO.Book;

namespace PaperCave.Infrastructure.Repository.Books
{
    public interface IBookRepository
    {
        public Task<IEnumerable<BookDTO>> GetBooksFromRepo(int count, int index);
    }
}
