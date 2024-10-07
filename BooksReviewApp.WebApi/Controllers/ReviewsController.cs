using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.WebApi.Dtos.Genre;
using BooksReviewApp.WebApi.Dtos.Review;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviewEntities = await _reviewService.GetAllAsync();
            var reviews = _mapper.Map<IEnumerable<ReadReviewDto>>(reviewEntities);

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById([FromRoute] Guid id)
        {
            var reviewEntity = await _reviewService.GetByIdAsync(id);
            if (reviewEntity == null)
            {
                return Ok(null);
            }

            var reviewDto = _mapper.Map<ReadGenreDto>(reviewEntity);

            return Ok(reviewDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto reviewDto)
        {
            var reviewEntity = _mapper.Map<Review>(reviewDto);
            var createdReview = await _reviewService.CreateAsync(reviewEntity);
            return Ok(createdReview.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewDto reviewDto)
        {
            var reviewEntity = _mapper.Map<Review>(reviewDto);
            var updatedReview = await _reviewService.UpdateAsync(reviewEntity);
            return Ok(updatedReview);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchGenre([FromBody] PatchReviewDto reviewDto)
        {
            var reviewEntity = _mapper.Map<Review>(reviewDto);
            var patchedReview = await _reviewService.PatchAsync(reviewEntity);
            return Ok(patchedReview);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview([FromRoute] Guid id)
        {
            var result = await _reviewService.DeleteAsync(id);

            return Ok(result);
        }
    }
}
