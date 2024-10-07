using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.WebApi.Dtos.Book;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var bookEntities = await _bookService.GetAllAsync();
            var books = _mapper.Map<IEnumerable<ReadBookDto>>(bookEntities);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] Guid id)
        {
            var bookEntity = await _bookService.GetByIdAsync(id);
            if (bookEntity == null)
            {
                return Ok(null);
            }

            var bookDto = _mapper.Map<ReadBookDto>(bookEntity);

            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto bookDto)
        {
            var bookEntity = _mapper.Map<Book>(bookDto);
            var createdBook = await _bookService.CreateAsync(bookEntity);
            return Ok(createdBook.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto bookDto)
        {
            var bookEntity = _mapper.Map<Book>(bookDto);
            var updatedBook = await _bookService.UpdateAsync(bookEntity);
            return Ok(updatedBook);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchBook([FromBody] PatchBookDto bookDto)
        {
            var bookEntity = _mapper.Map<Book>(bookDto);
            var patchedBook = await _bookService.PatchAsync(bookEntity);
            return Ok(patchedBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
            var result = await _bookService.DeleteAsync(id);

            return Ok(result);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetAllReviewsByBook()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}/genres")]
        public async Task<IActionResult> GetAllGenresByBook()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
