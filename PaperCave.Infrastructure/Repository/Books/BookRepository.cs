using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using PaperCave.DTO.Book;
using PaperCave.DTO.Configuration;

namespace PaperCave.Infrastructure.Repository.Books
{
    public sealed class BookRepository : IBookRepository
    {
        private readonly CosmosClient cosmosClient;
        private readonly CosmosSettings settings;
        public BookRepository(IOptions<CosmosSettings> settings)
        {
            this.settings = settings.Value;
            cosmosClient = new CosmosClient(settings.Value.Url, settings.Value.Key);
        }

        public Task<IEnumerable<BookDTO>> GetBooksFromRepo(int count, int index)
        {
            var client = GetCosmosClient();

            throw new NotImplementedException();
        }

        private CosmosClient GetCosmosClient()
            => cosmosClient ?? new CosmosClient(settings.Url, settings.Key);
    }
}
