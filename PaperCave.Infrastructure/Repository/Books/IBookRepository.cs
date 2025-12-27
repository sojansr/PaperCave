using PaperCave.DTO.Book;

namespace PaperCave.Infrastructure.Repository.Books
{
    public interface IBookRepository
    {
        public Task<IEnumerable<BookDTO>> GetAllBooks(int count, int index);

        public Task<BookDTO> GetBookByTitle(string title);
    }
}
