using PaperCave.Core.Models.Inventory;
using PaperCave.Core.Services.Inventory.Interfaces;
using Microsoft.Extensions.Logging;

namespace PaperCave.Core.Services.Inventory.Implementations
{
    public class InventoryService : IInventoryService
    {
        private readonly ILogger<InventoryService> _logger;
        public InventoryService(ILogger<InventoryService> logger)
        {
            _logger = logger;
        }
        public Task<IEnumerable<Book>> GetBooks(int count, int offset)
        {
            _logger.LogInformation("Inventory Service starting book list fetch for count {count} with offset {offset}", count, offset);
            throw new NotImplementedException();
        }
    }

}