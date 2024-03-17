using PaperCave.Core.Models.Inventory;

namespace PaperCave.Core.Services.Inventory.Interfaces
{
    public interface IInventoryService
    {
        public Task<IEnumerable<Book>> GetBooks(int count, int offset);
    }
}
