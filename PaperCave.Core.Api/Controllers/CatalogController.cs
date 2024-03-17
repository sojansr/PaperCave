#region Library Imports
using System.Net;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaperCave.Core.Models.Inventory;
using PaperCave.Core.Services.Inventory.Interfaces;
#endregion

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        #region Private Variables
        private IInventoryService _inventoryService;
        private ILogger<CatalogController> _logger;
        #endregion

        #region Constructors
        public CatalogController(IInventoryService inventoryService, 
            ILogger<CatalogController> logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }
        #endregion

        #region Endpoints
        [HttpGet("/GetBooks/{count}/{offset}")]
        public async Task<IActionResult> GetBooks([FromRoute]int count, [FromRoute]int offset)
        {
            _logger.LogInformation("Calling get api with id: {count}", count);
            try
            {
                var result = await _inventoryService.GetBooks(count, offset);
                if(result.Any())
                    return Ok();
                else
                    return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError("COntroller error: {message}, stack trace: {trace}}", ex.Message, ex.StackTrace);
            }
            return StatusCode(500);
        }
        #endregion
    }
}
