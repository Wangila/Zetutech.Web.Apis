using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zetutech.Web.Api.ApplicationCore.Entities
{   [Table("QUESTIONOPTIONS")]
    public class QuestionOption : BaseEntity
    {
        [Column("QUESITON_ID")]
        public int QuestionId { get; set;}
        [Column("TITLE")]
        public string Title { get; set; }
        [Column("IS_CORRECT")]
        public bool IsCorrect { get; set; }

    }
}
