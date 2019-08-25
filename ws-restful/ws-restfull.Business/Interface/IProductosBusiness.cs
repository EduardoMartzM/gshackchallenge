using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_restful.DomainModel;

namespace ws_restfull.Business.Interface
{
    public interface IProductosBusiness
    {
        bool AddProducto(ProductosDomainModel productoDM);

        ProductosDomainModel Get(int id);
        bool Delete(int id);
    }
}
