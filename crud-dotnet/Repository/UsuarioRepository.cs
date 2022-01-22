using crud_dotnet.Data;
using crud_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_dotnet.Repository
{
    public class UsuarioRepository : IuserRepository
    {
        private readonly UsuarioContext _context;
        public UsuarioRepository(UsuarioContext usuarioContext)
        {
            _context = usuarioContext;
        }
        public void AddUsuario(Usuarios usuario)
        {
            _context.Add(usuario);
        }

        public void AtualizaUsuario(Usuarios usuarios)
        {
            _context.Update(usuarios);
        }

        public async Task<IEnumerable<Usuarios>> BuscarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuarios> BuscarUsuario(int id)
        {
            return await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void DeletaUsuario(Usuarios usuarios)
        {
            _context.Remove(usuarios);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
