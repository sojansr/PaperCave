using Microsoft.AspNetCore.Mvc;
using PaperCave.Core.Services;

namespace PaperCave.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(ILogger<BookController> logger, IBookService bookService) : ControllerBase
    {
        /// <summary>
        /// Gets a list of books up to count and starting from index.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooksAsync([FromQuery] int count, [FromQuery] int index)
        {
            try
            {
                var books = await bookService.GetAllBooks(count, index);
                return Ok(books);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while fetching books.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
