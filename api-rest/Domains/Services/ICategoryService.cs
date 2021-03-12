using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domains.Models;
using api_rest.Communication;

namespace api_rest.Domains.Services
{
    public interface ICategoryService{

        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
         
    }
}