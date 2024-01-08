using Domain.Entities.Payments;
using Domain.Entities.Payments.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories.PaymentsRepositories;

public class PaymentRepository(AppDbContext appDbContext) : IPaymentRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<Payment> GetByIdAsync(int? id)
    {
        return await _appDbContext.Payments.FindAsync(id);
    }

    public async Task<IEnumerable<Payment>> GetPaymentsAsync()
    {
        return await _appDbContext.Payments
            .AsNoTracking()
            .ToListAsync();
    }

    //public async Task<IEnumerable<CreditCard>> GetPaymentsCreditCardAsync()
    //{
    //    return await _appDbContext.CreditCards
    //        .AsNoTracking()
    //        .Include(x => x.OrderDetails)
    //        .Include(x => x.Orders)
    //        .ToListAsync();
    //}

}
