using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.WebApi.Dtos.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authorEntities = await _authorService.GetAllAsync();
            var authors = _mapper.Map<IEnumerable<ReadAuthorDto>>(authorEntities);

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] Guid id)
        {
            var authorEntity = await _authorService.GetByIdAsync(id);
            if (authorEntity == null)
            {
                return Ok(null);
            }

            var authorDto = _mapper.Map<ReadAuthorDto>(authorEntity);

            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto authorDto)
        {
            var authorEntity = _mapper.Map<Author>(authorDto);
            var createdAuthor = await _authorService.CreateAsync(authorEntity);
            return Ok(createdAuthor.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDto authorDto)
        {
            var authorEntity = _mapper.Map<Author>(authorDto);
            var updatedAuthor = await _authorService.UpdateAsync(authorEntity);
            return Ok(updatedAuthor);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchAuthor([FromBody] PatchAuthorDto authorDto)
        {
            var authorEntity = _mapper.Map<Author>(authorDto);
            var patchedAuthor = await _authorService.PatchAsync(authorEntity);
            return Ok(patchedAuthor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
        {
            var result = await _authorService.DeleteAsync(id);

            return Ok(result);
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetBooksByAuthor(int authorId)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
