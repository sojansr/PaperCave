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

        public async Task<BookDTO> GetBookByTitle(string title)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Title", title);
            return await _databaseOperations.QuerySingleAsync<BookDTO>(QueryRegister.GetBookByTitle, parameters);
        }

        public async Task<int> InsertAuthor()
        {
            // Placeholder implementation to satisfy interface - repository author insertion
            await Task.CompletedTask;
            return 0;
        }

        public async Task<int> InsertBook(InsertBookDTO bookToInsert) 
        {
            var insertTime = DateTime.Now;
            DynamicParameters parameters = new();
            parameters.Add("@Title", bookToInsert.Title);
            parameters.Add("@Author", bookToInsert.Author);
            parameters.Add("@PageCount", bookToInsert.PageCount);
            parameters.Add("@AuthorId", bookToInsert.AuthorId);
            parameters.Add("@GenreId", bookToInsert.GenreId);
            parameters.Add("@CreatedTs", insertTime);
            parameters.Add("@UpdatedTs", insertTime);

            return await _databaseOperations.ExecuteAsync(QueryRegister.InsertBook, parameters);
        }
    }
}
