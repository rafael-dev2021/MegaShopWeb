using Domain.Entities.Payments;
using Domain.Entities.Payments.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories.Payments;

public class PaymentRepositories(AppDbContext appDbContext) : IPaymentRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Payment>> ListPaymentsAsync()
    {
        return await _appDbContext.Payments
            .AsNoTracking()
            .ToListAsync();
    }
}
