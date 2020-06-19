using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_demo.Models
{
    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BlogDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
