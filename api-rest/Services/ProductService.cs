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
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository){
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> ListAsync(){
            return await _productRepository.ListAsync();
        }
        
    }
}