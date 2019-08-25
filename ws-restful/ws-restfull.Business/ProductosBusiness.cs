using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ws.restful.Repository;
using ws.restful.Repository.Infraestructure.Contract;
using ws_restful.DomainModel;
using ws_restfull.Business.Interface;

namespace ws_restfull.Business
{
    public class ProductosBusiness : IProductosBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductosRepository productosRepository;
        public ProductosBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            productosRepository = new ProductosRepository(unitOfWork);
        }

        public bool AddProducto(ProductosDomainModel productoDM)
        {
            CatProductos catProductos = new CatProductos();
            bool respuesta = false;

            try
            {
                catProductos.Precio = productoDM.precio;
                catProductos.Stock = productoDM.Stock;
                catProductos.strNombre = productoDM.strNombre;
                respuesta = true;
            }
            catch (Exception ex)
            {

                throw new Exception("Hubo un error al insertar el producto, revise la exception." + ex.Message);
               
            }

            return respuesta;
                
        }
  
        public ProductosDomainModel Get(int id)
        {
            try
            {
                Expression<Func<CatProductos, bool>> predicado = p => p.id.Equals(id);
                CatProductos catProducto = productosRepository.GetAll(predicado).SingleOrDefault();
                ProductosDomainModel productoDM = new ProductosDomainModel();
                productoDM.id = catProducto.id;
                productoDM.precio = catProducto.Precio.Value;
                productoDM.Stock = catProducto.Stock.Value;
                productoDM.strNombre = catProducto.strNombre;
                return productoDM;
            }
            catch (Exception ex )
            {

                return  null;
            }
        }

        public bool Delete(int id)
        {

            bool respuesta = false;

            try
            {
                Expression<Func<CatProductos, bool>> predicate = p => p.id == id;

                productosRepository.Delete(predicate);
                respuesta = true;
            }
            catch (Exception)
            {

               
            }

            return respuesta;
          
        }



    }
}
