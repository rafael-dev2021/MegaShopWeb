using Application.Dtos.Reviews;
using Application.Services.CalculateWeightedAverageReviews.ValueObjects;

namespace Application.Services.CalculateWeightedAverageReviews.Interfaces;

public interface IWeightedAverageResult
{
    public WeightedAverageResultOV CalculateWeightedAverage(IEnumerable<ReviewDto> reviews);
}
