using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zetutech.Web.Api.ApplicationCore.Entities;

namespace Zetutech.Web.Api.Interfaces
{
    public interface IQuestionService
    {
       IEnumerable<Question> GetAll();
       Task<IEnumerable<Question>> GetAllAsync();
        Task<IEnumerable<Question>> GetAllAsync(int pageIndex, int itemsPage, int? questionId);
    }
}
