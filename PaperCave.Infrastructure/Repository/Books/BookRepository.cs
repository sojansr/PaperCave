using Dapper;
using PaperCave.DTO.Book;
using PaperCave.Infrastructure.Repository.Base;
using PaperCave.Infrastructure.Repository.Constants;

namespace PaperCave.Infrastructure.Repository.Books
{
    public sealed class BookRepository(IDatabaseOperations databaseOperations) : IBookRepository
    {
        private readonly IDatabaseOperations _databaseOperations = databaseOperations;

        public async Task<IEnumerable<BookDTO>> GetAllBooks(int count, int index)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Count", count);
            parameters.Add("@Index", index);
            return await _databaseOperations.QueryAsync<BookDTO>(QueryRegister.GetAllBooks, parameters);
        }
    }
}
