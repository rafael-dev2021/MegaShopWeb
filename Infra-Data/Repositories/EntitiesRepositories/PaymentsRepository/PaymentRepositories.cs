using Domain.Entities.Payments;
using Domain.Entities.Payments.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories.PaymentsRepository;

public class PaymentRepositories(AppDbContext appDbContext) : IPaymentRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<PaymentMethod>> ListPaymentsAsync() =>
            await _appDbContext.PaymentMethods
            .AsNoTracking()
            .Include(x=>x.CreditCard)
            .Include(x=>x.DebitCard)
            .Include(x => x.PaymentMethodObjectValue)
            .ThenInclude(x => x.PaymentStatusObjectValue)
            .ToListAsync();

    public async Task<IEnumerable<CreditCard>> ListPaymentCreditCardsAsync() =>
            await _appDbContext.CreditCards
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync();

    public async Task<IEnumerable<DebitCard>> ListPaymentDebitCardsAsync() =>
            await _appDbContext.DebitCards
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync();

    public async Task<PaymentMethod> GetByIdPaymentAsync(int? id) =>
           await _appDbContext.PaymentMethods
           .Include(x => x.PaymentMethodObjectValue)
           .ThenInclude(x => x.PaymentStatusObjectValue)
           .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<CreditCard> GetByIdPaymentCreditCardAsync(Guid? id) =>
           await _appDbContext.CreditCards.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<DebitCard> GetByIdPaymentDebitCardAsync(Guid? id) =>
           await _appDbContext.DebitCards.FirstOrDefaultAsync(x => x.Id == id);


    //public Task<IEnumerable<Payment>> ListPaymentBankSlipAsync()
    //{
    //    throw new NotImplementedException();
    //}
}
