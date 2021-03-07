using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api_rest.Domains.Models;
using api_rest.Domains.Services;

namespace api_rest.Controllers
{
    [Route("/api/[controller]")]
        
    public class CategoryController : Controller{
        
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService){
            this._categoryService = categoryService;
        }

        [HttpGet]

        public async Task<IEnumerable<Category>> GetAllAsync(){

            var categories = await _categoryService.ListAsync();

            return categories;
        }

    }
}