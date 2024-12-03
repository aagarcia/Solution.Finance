using Solution.Finance.Domain.Entities;

namespace Solution.Finance.Application.Interfaces.Persistence
{
    public interface IUsuarioContext
    {
        Task<List<Usuario>> ObtenerUsuarios();
        Task<Usuario> ObtenerUsuario(string id);
        Task<string> CrearUsuario(Usuario usuario);
        Task<bool> ActualizarUsuario(Usuario usuario);
        Task<bool> EliminarUsuario(Usuario usuario);
    }
}
