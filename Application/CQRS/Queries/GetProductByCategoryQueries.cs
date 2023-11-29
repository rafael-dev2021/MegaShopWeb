using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetProductByCategoryQueries(string categoryStr) : IRequest<IEnumerable<Product>>
    {
        public string CategoryStr { get; set; } = categoryStr;
    }
}
