using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using api_rest.Resources;
using api_rest.Domains.Models;
using api_rest.Extensions;

namespace api_rest.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile(){
            CreateMap<Category,CategoryResource>();
            CreateMap<Product,ProductResource>().ForMember(src=> src.UnitOfMeasurement,
                opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}