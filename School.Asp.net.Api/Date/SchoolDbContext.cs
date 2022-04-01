using Microsoft.EntityFrameworkCore;
using School.Asp.net.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Asp.net.Api.Date
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options):base(options)
        {   }
      public DbSet<Class>Class { get; set; }
        public DbSet<Pupil> Pupil { get; set; }

   
    }
}
