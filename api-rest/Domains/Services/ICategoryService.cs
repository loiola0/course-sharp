using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domains.Models;

namespace api_rest.Domains.Services
{
    public interface ICategoryService{

        Task<IEnumerable<Category>> ListAsync();
         
    }
}