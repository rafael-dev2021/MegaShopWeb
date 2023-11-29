using Application.Services.CalculateWeightedAverageReviews.ValueObjects;
using Domain.Entities.Reviews;

namespace Application.Services.CalculateWeightedAverageReviews.Interfaces
{
    public interface IWeightedAverageResult
    {
        public WeightedAverageResultOV CalculateWeightedAverage(IEnumerable<Review> reviews);
    }
}
