using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.ComTypes;

namespace WebApplication1.Data
{
    public class ApiModelsContext :DbContext
    {
        public ApiModelsContext(DbContextOptions<ApiModelsContext> options)
            : base(options)
        {
        }
        public DbSet<English> Englishes { get; set; }
        public DbSet<Thai> Thais { get; set; }

        public DbSet<chart> charts { get; set; }
    }
}
