using PaperCave.DTO.Book;
using PaperCave.Infrastructure.Repository.Books;

namespace PaperCave.Core.Services
{
    public sealed class BookService(IBookRepository bookRepository) : IBookService
    {
        public async Task<IEnumerable<BookDTO>> GetAllBooks(int count, int index)
        {
            return await bookRepository.GetAllBooks(count, index);
        }

        public async Task<BookDTO> GetBookByTitle(string title)
        {
            return await bookRepository.GetBookByTitle(title);
        }
    }
}
