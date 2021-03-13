using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domains.Models;
using api_rest.Domains.Services;
using api_rest.Domains.Repositories;
using api_rest.Communication;

namespace api_rest.Services
{
    public class CategoryService : ICategoryService{
        
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfwork;

        public CategoryService(ICategoryRepository categoryRespository,IUnitOfWork unitOfWork){
            _categoryRepository = categoryRespository;
            _unitOfwork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync(){
            
            return await _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category){
            try{
                await _categoryRepository.AddAsync(category);
                await _unitOfwork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch(Exception ex){
                return new SaveCategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse> UpdateAsync(int id, Category category){
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if(existingCategory == null){
                return new SaveCategoryResponse("Category not found.");
            }
            
            existingCategory.Name = category.Name;

            try{
                _categoryRepository.Update(existingCategory);
                await _unitOfwork.CompleteAsync();

                return new SaveCategoryResponse(existingCategory);

            }catch(Exception ex){
                return new SaveCategoryResponse($"an error occurred when updating the category: {ex.Message}");
            }

        }
        
    }
}