using Application.Dtos.Reviews;
using Application.Interfaces.Entities;
using AutoMapper;
using Domain.Entities.Reviews;
using Domain.Interfaces.Reviews;

namespace Application.Services.Entities
{
    public class ReviewDtoService(IReviewRepository repository, IMapper mapper) : IReviewDtoService
    {
        private readonly IReviewRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ReviewDto>> GetReviewsDtoAsync()
        {
            var reviewsDto = await _repository.GetReviewsAsync();
            if (reviewsDto == null || !reviewsDto.Any())
            {
                return new List<ReviewDto>();
            }
            return _mapper.Map<IEnumerable<ReviewDto>>(reviewsDto);
        }

        public async Task<ReviewDto> GetByIdAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "Review ID cannot be null.");

            var getReviewId = await _repository.GetByIdAsync(id);

            if (getReviewId == null)
                throw new Exception($"Review with ID {id} not found.");

            return _mapper.Map<ReviewDto>(getReviewId);
        }

        public async Task AddReview(ReviewDto reviewDto)
        {
            if (reviewDto == null)
                throw new ArgumentNullException(nameof(reviewDto), "ReviewDto cannot be null.");

            var addReview = _mapper.Map<Review>(reviewDto);
            await _repository.CreateReview(addReview);
        }

        public async Task DeleteReview(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "Review ID cannot be null.");

            var deleteReview = await _repository.GetByIdAsync(id);

            if (deleteReview == null)
                throw new Exception($"Review with ID {id} not found.");

            await _repository.RemoveReview(deleteReview);
        }

        public async Task UpdateReview(ReviewDto reviewDto)
        {
            if (reviewDto == null)
                throw new ArgumentNullException(nameof(reviewDto), "ReviewDto cannot be null.");

            var updateReview = _mapper.Map<Review>(reviewDto);
            await _repository.UpdateReview(updateReview);
        }
    }
}
