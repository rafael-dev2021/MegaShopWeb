using Domain.Entities.Cart.Interfaces;
using Domain.Entities.Orders;
using Domain.Entities.Orders.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories.OrdersRepositories;

public class OrderRepository(AppDbContext appDbContext, IShoppingCartItemRepository shoppingCartItemRepository) : IOrderRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository = shoppingCartItemRepository;
    public async Task CreateOrder(Order order)
    {
        //    order.ConfirmedOrder = DateTime.Now;
        //    _appDbContext.Orders.Add(order);
        //    var payment = order.Payment;
        //    // Realize as validações necessárias para o objeto Payment
        //    if (payment == null || payment.PaymentMethod == null || payment.CardNumber == null || payment.CardHolderName == null || payment.ExpirationDate == null || payment.SecurityCode == null)
        //    {
        //        throw new Exception("Invalid payment information");
        //    }
        //    _appDbContext.SaveChanges();

        //    var cartItems = await _shoppingCartItemRepository.GetShoppingCartItemsAsync();

        //    foreach (var cartItem in cartItems)
        //    {
        //        var produto = _appDbContext.Products.Find(cartItem.Product.Id);

        //        if (produto != null && produto.Stock >= cartItem.Quantity)
        //        {
        //            produto.Stock -= cartItem.Quantity;
        //            var pedidoDetail = new OrderDetail()
        //            {
        //                Quantity = cartItem.Quantity,
        //                ProductId = cartItem.Product.Id,
        //                OrderId = order.Id,
        //                Price = cartItem.Product.ProductPriceObjectValue.Price
        //            };
        //            _appDbContext.OrderDetails.Add(pedidoDetail);
        //        }
        //        else
        //        {
        //            throw new Exception("Product stock not available");
        //        }
        //    }
        //    _appDbContext.SaveChanges();
        //}
        using var transaction = _appDbContext.Database.BeginTransaction();
        try
        {
            order.ConfirmedOrder = DateTime.Now;
            _appDbContext.Add(order);
            await _appDbContext.SaveChangesAsync();

            var cartItems = await _shoppingCartItemRepository.GetShoppingCartItemsAsync();

            foreach (var cartItem in cartItems)
            {
                var product = await _appDbContext.Products.FindAsync(cartItem.Product.Id);
                if (product.Stock >= cartItem.Quantity)
                {
                    product.Stock -= cartItem.Quantity;
                    var orderDetails = new OrderDetail()
                    {
                        Quantity = cartItem.Quantity,
                        Price = cartItem.Product.ProductPriceObjectValue.Price,
                        OrderId = order.Id,
                        ProductId = cartItem.Product.Id
                    };
                    _appDbContext.OrderDetails.Add(orderDetails);
                }
                else
                {
                    transaction.Rollback();
                    throw new Exception("Product stock not available.");
                }
            }
            await _appDbContext.SaveChangesAsync();

            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("There was an error processing the request.", ex);
        }
    }

    public async Task<Order> GetByIdAsync(int? id)
    {
        return await _appDbContext.Orders.FindAsync(id);
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _appDbContext.Orders
             .AsNoTracking()
             .Include(x => x.Payment)
             .Include(x => x.OrderDetails)
             .OrderBy(x => x.Id)
             .ToListAsync();
    }

    public async Task<IEnumerable<OrderDetail>> GetOrdersDetailsAsync()
    {
        return await _appDbContext.OrderDetails
            .AsNoTracking()
            .Include(x => x.Product)
            .Include(x => x.Order)
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<Order> RemoveOrder(Order order)
    {
        _appDbContext.Remove(order);
        await _appDbContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order> UpdateOrder(Order order)
    {
        _appDbContext.Update(order);
        await _appDbContext.SaveChangesAsync();
        return order;
    }
}


//public async Task<IEnumerable<Order>> GetOrdersAsync(string searchKeyword = null, DateTime? startDate = null, DateTime? endDate = null)
//{
//    var query = _appDbContext.Orders
//         .AsNoTracking()
//         .Include(x => x.Payment)
//         .Include(x => x.OrderDetails)
//         .OrderBy(x => x.Id);

//    if (!string.IsNullOrWhiteSpace(searchKeyword))
//    {
//        query = query.Where(x => x.CustomerName.Contains(searchKeyword) || x.OrderNumber.Contains(searchKeyword));
//    }

//    if (startDate.HasValue)
//    {
//        query = query.Where(x => x.ConfirmedOrder >= startDate.Value);
//    }

//    if (endDate.HasValue)
//    {
//        query = query.Where(x => x.ConfirmedOrder <= endDate.Value);
//    }

//    return await query.ToListAsync();
//}
