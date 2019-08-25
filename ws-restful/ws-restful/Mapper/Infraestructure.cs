using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ws_restful.DomainModel;
using ws_restful.ViewModels;

namespace ws_restful.Mapper
{
    public class AutoMapperWebProfile:AutoMapper.Profile
    {
        public AutoMapperWebProfile()
        {
            CreateMap<ProductosViewModel, ProductosDomainModel>();
            CreateMap<ProductosDomainModel, ProductosViewModel>();
        }
    }
}