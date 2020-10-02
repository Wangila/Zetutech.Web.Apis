using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zetutech.Web.Api.ApplicationCore.Entities;

namespace Zetutech.Web.Api.Infrastructure.Data
{
    public class ZetutechDataDbContext : DbContext
    {
        public ZetutechDataDbContext(DbContextOptions<ZetutechDataDbContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
    }
}
