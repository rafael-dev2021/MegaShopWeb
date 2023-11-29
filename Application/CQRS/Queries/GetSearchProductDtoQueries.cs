using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetSearchProductDtoQueries(string keyword) : IRequest<IEnumerable<Product>>
    {
        public string Keyword { get; set; } = keyword;
    }
}
