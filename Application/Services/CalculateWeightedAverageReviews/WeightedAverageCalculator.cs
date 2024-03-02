using Application.Dtos.Reviews;
using Application.Services.CalculateWeightedAverageReviews.Interfaces;
using Application.Services.CalculateWeightedAverageReviews.ValueObjects;

namespace Application.Services.CalculateWeightedAverageReviews;

public class WeightedAverageCalculator : IWeightedAverageResult
{
    public WeightedAverageResultOV CalculateWeightedAverage(IEnumerable<ReviewDto> reviewsDto)
    {
        var countRating = 0;
        var maxRating = 5.0;
        var result = new WeightedAverageResultOV();

        foreach (var item in reviewsDto)
        {
            countRating += item.Rating;
            result.CountReviews++;
        }

        if (result.CountReviews > 0)
        {
            var averageRating = countRating / result.CountReviews;
            var weight = maxRating / averageRating;

            if (weight < 1)
            {
                result.WeightedAverage = averageRating * weight;
            }
            else
            {
                result.WeightedAverage = averageRating;
            }
        }
        else
        {
            result.WeightedAverage = 0.0;
        }

        return result;
    }
}
