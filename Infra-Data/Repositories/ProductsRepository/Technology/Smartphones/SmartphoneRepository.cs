using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Smartphones;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.ProductsRepository.Technology.Smartphones
{
    public class SmartphoneRepository(AppDbContext appDbContext) : ISmartphoneRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<IEnumerable<Smartphone>> GetProductsAsync()
        {
            return await _appDbContext.Smartphones
                .AsNoTracking()
                .Include(x => x.Category)
                .OrderBy(x => x.Name)
                //.Include(x => x.Reviews)
                .ToListAsync();
        }

        public async Task<Smartphone> GetByIdAsync(int? id)
        {
            return await _appDbContext.Smartphones.FindAsync(id);
        }

        public async Task<Smartphone> UpdateAsync(Smartphone entity)
        {
            _appDbContext.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Smartphone> CreateAsync(Smartphone entity)
        {
            _appDbContext.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Smartphone> DeleteAsync(Smartphone entity)
        {
            _appDbContext.Remove(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
