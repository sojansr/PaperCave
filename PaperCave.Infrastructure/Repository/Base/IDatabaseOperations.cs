namespace PaperCave.Infrastructure.Repository.Base
{
    public interface IDatabaseOperations
    {
        public Task<IEnumerable<T>> QueryAsync<T>(string storedProc, object parameters);
        public Task<int> ExecuteAsync(string storedProc, object parameters);
    }
}
