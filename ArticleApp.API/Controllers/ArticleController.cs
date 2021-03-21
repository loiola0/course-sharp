using System;
using System.Linq;
using ArticleApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using ArticleApp.API.Util;

namespace ArticleApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {

        private readonly DataContext _context = null;
        
        public ArticleController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll(){
            return Ok(_context.Articles.Select(s=>StringProcessor.ToUpperCase(s.Name)).ToList());
        }
        
    }
}