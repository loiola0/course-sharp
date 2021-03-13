using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domains.Repositories;
using api_rest.Persistence.Contexts;

namespace api_rest.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public UnitOfWork(AppDbContext context){
            _context = context;
        }

        public async Task CompleteAsync(){
            await _context.SaveChangesAsync();
        }

    }
}