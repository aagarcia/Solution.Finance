using AutoMapper;
using Solution.Finance.Application.Interfaces.Persistence;
using Solution.Finance.Application.UseCases.Commons.DTOs.Usuario;
using Solution.Finance.Application.UseCases.IFeatures;
using Solution.Finance.Domain.Entities;

namespace Solution.Finance.Application.UseCases.Features
{
    public class UsuarioHandler : IUsuarioHandler
    {
        private readonly IUsuarioContext _usuarioContext;
        private readonly IMapper _mapper;

        public UsuarioHandler(IUsuarioContext usuarioContext, IMapper mapper)
        {
            _usuarioContext = usuarioContext;
            _mapper = mapper;
        }

        public async Task<List<RespuestaUsuarioDTO>> ObtenerUsuarios()
        {
            var result = await _usuarioContext.ObtenerUsuarios();

            var usuarioDTO = _mapper.Map<List<RespuestaUsuarioDTO>>(result);

            return usuarioDTO;
        }

        public async Task<RespuestaUsuarioDTO> ObtenerUsuario(string id)
        {
            var result = await _usuarioContext.ObtenerUsuario(id);

            var usuarioDTO = _mapper.Map<RespuestaUsuarioDTO>(result);

            return usuarioDTO;
        }

        public async Task<RespuestaUsuarioDTO> CrearUsuario(CrearUsuarioDTO crearUsuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(crearUsuarioDTO);

            var respuesta = await _usuarioContext.CrearUsuario(usuario);

            var respuestaUsuarioDTO = await ObtenerUsuario(respuesta);

            return respuestaUsuarioDTO;
        }

        public async Task<bool> ActualizarUsuario(ActualizarUsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            var respuesta = await _usuarioContext.ActualizarUsuario(usuario);

            return respuesta;
        }

        public async Task<bool> EliminarUsuario(EliminarUsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            var respuesta = await _usuarioContext.EliminarUsuario(usuario);

            return respuesta;
        }
    }
}
