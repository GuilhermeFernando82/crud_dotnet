using crud_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_dotnet.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuario = modelBuilder.Entity<Usuarios>();
            usuario.ToTable("tb_usuario");
            usuario.HasKey(u => u.Id);
            usuario.Property(u => u.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(u => u.Name).HasColumnName("name").IsRequired();
            usuario.Property(U => U.dataNascimento).HasColumnName("data");
        }

        internal Task<int> SaveChange()
        {
            throw new NotImplementedException();
        }
    }
}
