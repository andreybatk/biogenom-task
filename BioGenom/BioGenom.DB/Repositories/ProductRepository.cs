using Microsoft.EntityFrameworkCore;

namespace BioGenom.DB.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Проверяет, существует ли продукт с заданным идентификатором.
        /// </summary>
        public async Task<bool> ExistsAsync(Guid productId)
        {
            if (productId == Guid.Empty)
                return false;

            return await _context.Products.AnyAsync(p => p.Id == productId);
        }
    }
}
