using Microsoft.EntityFrameworkCore;
using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Models
{
   public class TodoDatabaseContext : DbContext
    {
        public TodoDatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoDetails> TodoDetail {get; set;}
    }
}
