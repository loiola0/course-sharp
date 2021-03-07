using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domains.Helpers;

namespace api_rest.Domains.Models
{
    public class Product{
        
        public int Id {get;set;}
        public string Name {get;set;}
        public short QuantityPackage {get;set;}
        public EUnitOfMeasurement UnitOfMeasurement {get;set;}
        public int CategoryId {get;set;}
        public Category Category{get;set;}
        
    }
}