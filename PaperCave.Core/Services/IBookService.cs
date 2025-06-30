using PaperCave.Core.DTOs;

namespace PaperCave.Core.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDTO>> GetAllBooks(int count, int index);
    }
}
