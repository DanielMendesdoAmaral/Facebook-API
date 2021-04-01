using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class FacebookContext : DbContext
    {
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public FacebookContext(DbContextOptions<FacebookContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(@"Data Source=desktop-h1nfq8t\SQLEXPRESS;Initial Catalog=facebook;User ID=sa;Password=sa132");

                base.OnConfiguring(optionBuilder);
            }
        }
    }
}
