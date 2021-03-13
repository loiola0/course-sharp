using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using api_rest.Domains.Models;
using api_rest.Domains.Services;
using AutoMapper;
using api_rest.Resources;
using api_rest.Extensions;

namespace api_rest.Controllers
{
    [Route("/api/[controller]")]
        
    public class CategoryController : Controller{
        
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper){
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync(){

            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>,IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource){
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = _mapper.Map<SaveCategoryResource,Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if(!result.Success){
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] SaveCategoryResource resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }
            var category = _mapper.Map<SaveCategoryResource,Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if(!result.Success){
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category,CategoryResource>(result.Category);
            return Ok(categoryResource);

        }

    }
}