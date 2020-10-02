
using System.Collections.Generic;
using Zetutech.Web.Api.ApplicationCore.Entities;
using Zetutech.Web.Api.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Zetutech.Web.Api.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly ZetutechDataDbContext _dbContext;

        public EfRepository(ZetutechDataDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
            //return await _dbContext.Set<T>().ToAsyncEnumerable().ToList();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            //Eager of related entities
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().Include("QuestionOptions").AsQueryable(), spec);
        }

        

        public async Task<IEnumerable<T>> ListAllAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

    }
}
