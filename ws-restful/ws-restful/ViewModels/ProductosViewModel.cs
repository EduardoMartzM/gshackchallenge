using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_restful.ViewModels
{
    public class ProductosViewModel
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
    }
}