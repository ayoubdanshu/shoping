using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Migrations
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;

        }

        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id );
        }
    }
}