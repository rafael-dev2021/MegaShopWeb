using Domain.Entities.Products.Fashion.ProductShoes;
using MediatR;

namespace Application.CQRS.Queries.Products.Fashion.ShoesQueries;

public class GetShoesQueries : IRequest<IEnumerable<Shoes>>
{ }
