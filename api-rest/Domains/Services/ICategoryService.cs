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
        Task<CategoryResponse> SaveAsync(Category category);

        Task <CategoryResponse> UpdateAsync(int id,Category category);

        Task <CategoryResponse> DeleteAsync(int id);
         
    }
}