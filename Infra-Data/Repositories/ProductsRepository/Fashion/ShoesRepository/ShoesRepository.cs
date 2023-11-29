using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.Shoes;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.ProductsRepository.Fashion.ShoesRepository
{
    public class ShoesRepository(AppDbContext appDbContext) : IShoesRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<IEnumerable<Shoes>> GetProductsAsync()
        {
            return await _appDbContext.Shoes
               .AsNoTracking()
               .Include(x => x.Category)
               .OrderBy(x => x.Name)
               //.Include(x => x.Reviews)
               .ToListAsync();
        }

        public async Task<Shoes> GetByIdAsync(int? id)
        {
            return await _appDbContext.Shoes.FindAsync(id);
        }

        public async Task<Shoes> UpdateAsync(Shoes entity)
        {
            _appDbContext.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Shoes> CreateAsync(Shoes entity)
        {
            _appDbContext.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Shoes> DeleteAsync(Shoes entity)
        {
            _appDbContext.Remove(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
