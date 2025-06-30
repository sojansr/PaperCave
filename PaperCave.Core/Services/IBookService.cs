using PaperCave.DTO.Book;

namespace PaperCave.Core.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDTO>> GetAllBooks(int count, int index);
    }
}
