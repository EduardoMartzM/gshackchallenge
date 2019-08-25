using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ws_restful.DomainModel;
using ws_restful.ViewModels;
using ws_restfull.Business.Interface;

namespace ws_restful.Controllers
{
    public class ProductosController : ApiController
    {

        private IProductosBusiness productosBusiness;

        public ProductosController(IProductosBusiness _productosBusiness)
        {
            productosBusiness = _productosBusiness;
        }

        public void RegistrarProductos(ProductosViewModel productosViewModel)
        {
            ProductosDomainModel productosDM = new ProductosDomainModel();
           
            try
            {
                AutoMapper.Mapper.Map(productosViewModel, productosDM);
                productosBusiness.AddProducto(productosDM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                 ProductosDomainModel productoDM= productosBusiness.Get(id);
                 ProductosViewModel productosVM = new ProductosViewModel();
                 AutoMapper.Mapper.Map(productoDM, productosVM);
                if (productosVM != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, productosVM);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Recurso No Encontrado");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Recurso No Encontrado");

            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] ProductosViewModel productosVM)
        {
            try
            {
                ProductosDomainModel productosDM = new ProductosDomainModel();
                AutoMapper.Mapper.Map(productosVM, productosDM);
                productosBusiness.AddProducto(productosDM);
                var mensaje = Request.CreateResponse(HttpStatusCode.Created, productosDM);
                return mensaje;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                
            }

            
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            ProductosDomainModel productosDM = productosBusiness.Get(id);

           
                try
                {
                    productosBusiness.Delete(productosDM.id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Entidad Eliminada Correctamente");
                }
                catch (Exception)
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound, "La Entidad a Eliminar no se ha Encontrado");
                }
             
            

           
        }


    }
}
