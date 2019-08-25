using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws.restful.Repository.Infraestructure;
using ws.restful.Repository.Infraestructure.Contract;

namespace ws.restful.Repository
{
    public class ProductosRepository : BaseRepository<CatProductos>
    {
        public ProductosRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
