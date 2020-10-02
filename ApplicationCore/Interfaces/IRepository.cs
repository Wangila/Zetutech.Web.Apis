using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zetutech.Web.Api.ApplicationCore.Entities;

namespace Zetutech.Web.Api.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> ListAll();
    }
}
