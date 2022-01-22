using crud_dotnet.Models;

namespace crud_dotnet.Repository
{
    public interface IuserRepository
    {
        Task<IEnumerable<Usuarios>> BuscarUsuarios();
        Task<Usuarios> BuscarUsuario(int id);
        void AddUsuario(Usuarios usuarios);
        void AtualizaUsuario(Usuarios usuarios);
        void DeletaUsuario(Usuarios usuarios);
        Task<bool> SaveChangesAsync();
    }
}
