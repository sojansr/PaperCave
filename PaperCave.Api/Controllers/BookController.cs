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

        /// <summary>
        /// Gets a book by its title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet("GetBookByTitle")]
        public async Task<IActionResult> GetBookByTitleAsync([FromQuery] string title)
        {
            try
            {
                var book = await bookService.GetBookByTitle(title);
                if (book == null)
                    return NotFound();
                
                return Ok(book);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while fetching the book by title.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
