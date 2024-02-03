using Application.Dtos.Reviews;

namespace Application.Services.Entities.Interfaces;

public interface IReviewDtoService
{
    Task<IEnumerable<ReviewDto>> GetReviewsDtoAsync();
    Task<ReviewDto> GetByIdAsync(int? id);

    Task AddReview(ReviewDto reviewDto);
    Task UpdateReview(ReviewDto reviewDto);
    Task DeleteReview(int? id);
}
