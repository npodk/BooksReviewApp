using AutoMapper;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.Services.EF.Interfaces;
using BooksReviewApp.WebApi.Dtos.Author;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorDbService _authorDbService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorDbService authorDbService, IMapper mapper)
        {
            _authorDbService = authorDbService ?? throw new ArgumentNullException(nameof(authorDbService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authorEntities = await _authorDbService.GetAllAsync();
            var authors = _mapper.Map<IEnumerable<ReadAuthorDto>>(authorEntities);

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            var authorEntity = await _authorDbService.GetByIdAsync(id);
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
            var createdAuthor = await _authorDbService.CreateAsync(authorEntity);
            return Ok(createdAuthor.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDto authorDto)
        {
            var authorEntity = _mapper.Map<Author>(authorDto);
            var updatedAuthor = await _authorDbService.UpdateAsync(authorEntity);
            return Ok(updatedAuthor);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchUser([FromBody] PatchAuthorDto authorDto)
        {
            var authorEntity = _mapper.Map<Author>(authorDto);
            var patchedAuthor = await _authorDbService.PatchAsync(authorEntity);
            return Ok(patchedAuthor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
        {
            var result = await _authorDbService.DeleteAsync(id);

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
