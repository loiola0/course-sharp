using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domains.Models;
using api_rest.Domains.Services;
using api_rest.Domains.Repositories;

namespace api_rest.Services
{
    public class CategoryService : ICategoryRespository{
        
        private readonly ICategoryRespository _categoryRepository;

        public CategoryService(ICategoryRespository categoryRespository){
            this._categoryRepository = categoryRespository;
        }

        public async Task<IEnumerable<Category>> ListAsync(){
            
            return await _categoryRepository.ListAsync();
        }
        
    }
}