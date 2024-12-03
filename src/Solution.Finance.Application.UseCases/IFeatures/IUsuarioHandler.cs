using Solution.Finance.Application.UseCases.Commons.DTOs.Usuario;

namespace Solution.Finance.Application.UseCases.IFeatures
{
    public interface IUsuarioHandler
    {
        Task<List<RespuestaUsuarioDTO>> ObtenerUsuarios();
        Task<RespuestaUsuarioDTO> ObtenerUsuario(string id);
        Task<RespuestaUsuarioDTO> CrearUsuario(CrearUsuarioDTO usuarioDTO);
        Task<bool> ActualizarUsuario(ActualizarUsuarioDTO usuarioDTO);
        Task<bool> EliminarUsuario(EliminarUsuarioDTO usuarioDTO);
    }
}
