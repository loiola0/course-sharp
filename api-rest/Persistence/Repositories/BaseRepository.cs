using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Persistence.Contexts;

namespace api_rest.Persistence.Repositories
{
    public abstract class BaseRepository{
        //which gives access to all methods of
        //that we need to handle database operations.
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context){
            _context = context;
        }

    }
}