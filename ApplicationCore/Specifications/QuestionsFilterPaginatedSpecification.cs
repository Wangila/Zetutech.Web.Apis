using System;
using System.Collections.Generic;
using System.Text;
using Zetutech.Web.Api.ApplicationCore.Entities;

namespace Zetutech.Web.Api.ApplicationCore.Specifications
{
    public class QuestionsFilterPaginatedSpecification : BaseSpecification<Question>
    {
        public QuestionsFilterPaginatedSpecification(int skip, int take, int? questionId)
            : base(i => (!questionId.HasValue || i.Id == questionId))
        {
            ApplyPaging(skip, take);
        }
    }
}
