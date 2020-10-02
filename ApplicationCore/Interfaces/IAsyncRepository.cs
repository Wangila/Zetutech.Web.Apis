using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zetutech.Web.Api.ApplicationCore.Entities;

namespace Zetutech.Web.Api.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
       
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListAllAsync(ISpecification<T> spec);
    }
}
