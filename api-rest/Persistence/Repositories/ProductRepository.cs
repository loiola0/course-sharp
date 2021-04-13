using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domains.Repositories;
using api_rest.Domains.Models;
using api_rest.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        
        public ProductRepository(AppDbContext context) : base(context) {

        }

        public async Task<IEnumerable<Product>> ListAsync(){
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }


    }
}