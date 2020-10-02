using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zetutech.Web.Api.ApplicationCore.Entities
{   [Table("QUESTIONS")]
    public class Question : BaseEntity
    {
        [Column("TITLE")]
        public string Title { get; set; }
        //[Column("QUESITON_LANGUAGE_ID")]
        //public int QuestionLanguageId { get; set; }
        //[Column("QUESITON_LANGUAGE_TOPIC_ID")]
        //public int QuestionLanguageTopicId { get; set; }
        public List<QuestionOption> QuestionOptions { get; set; }
    }
}
