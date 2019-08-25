using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws.restful.Repository.Infraestructure.Contract
{
    public interface IUnitOfWork: IDisposable
    {
        DbContext Db { get; }
    }
}
