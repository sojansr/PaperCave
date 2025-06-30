using PaperCave.Core.DTOs;
using PaperCave.Core.Services;

namespace PaperCave.Core.Services
{
    public sealed class BookService : IBookService
    {
        public Task<IEnumerable<BookDTO>> GetAllBooks(int count, int index)
        {
            throw new NotImplementedException();
        }
    }
}
