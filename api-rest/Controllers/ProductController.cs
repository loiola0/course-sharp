using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using api_rest.Domains.Models;
using api_rest.Domains.Services;
using api_rest.Resources;


namespace api_rest.Controllers
{
    [Route("/api/[controller]")]
   public class ProductController : Controller
    {
        //Usaremos este campo para acessar os métodos de implementação de
        //nosso serviço de categoria.
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        //significa que a instância pode ser qualquer coisa que implemente a
        //interface de serviço
        public ProductController(IProductService productService,IMapper mapper){
            _productService = productService;
            _mapper = mapper;
        }


        /*
        O método usa nossa instância de serviço de categoria para listar todas as categorias e, em
        seguida, retorna as categorias ao cliente. O pipeline da estrutura lida com a serialização de
        dados para um objeto JSON. O tipo IEnumerable <Category> informa à estrutura que
        queremos retornar uma enumeração de categorias, e o tipo Task, precedido pela
        palavra-chave async, informa ao pipeline que esse método deve ser executado de forma
        assíncrona. Finalmente, quando definimos um método assíncrono, temos que usar a
        palavra-chave await para tarefas que podem demorar um pouco.
        */
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync(){
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductResource>>(products);
            return resources;
        }

        
    }
}