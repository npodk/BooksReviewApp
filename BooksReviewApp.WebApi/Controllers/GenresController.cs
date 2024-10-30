using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.WebApi.Dtos.Genre;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genreEntities = await _genreService.GetAllAsync();
            var genres = _mapper.Map<IEnumerable<ReadGenreDto>>(genreEntities);

            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById([FromRoute] Guid id)
        {
            var genreEntity = await _genreService.GetByIdAsync(id);
            if (genreEntity == null)
            {
                return Ok(null);
            }

            var genreDto = _mapper.Map<ReadGenreDto>(genreEntity);

            return Ok(genreDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDto genreDto)
        {
            var genreEntity = _mapper.Map<Genre>(genreDto);
            var createdGenre = await _genreService.CreateAsync(genreEntity);
            return Ok(createdGenre.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreDto genreDto)
        {
            var genreEntity = _mapper.Map<Genre>(genreDto);
            var updatedGenre = await _genreService.UpdateAsync(genreEntity);
            return Ok(updatedGenre);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchGenre([FromBody] PatchGenreDto genreDto)
        {
            var genreEntity = _mapper.Map<Genre>(genreDto);
            var patchedGenre = await _genreService.PatchAsync(genreEntity);
            return Ok(patchedGenre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] Guid id)
        {
            var result = await _genreService.DeleteAsync(id);

            return Ok(result);
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetAllBooksByGenre()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
