using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Solution.Finance.Application.UseCases.Commons.DTOs.Usuario;
using Solution.Finance.Application.UseCases.IFeatures;

namespace Solution.Finance.Service.Endpoints
{
    public static class UsuariosEndpoints
    {
        public static RouteGroupBuilder MapUsuarios(this RouteGroupBuilder builder)
        {
            builder.MapGet("/", ObtenerUsuarios);
            builder.MapGet("/{id}", ObtenerUsuario);
            builder.MapPost("/", CrearUsuario);
            builder.MapPut("/", ActualizarUsuario);
            builder.MapDelete("/", EliminarUsuario);
            return builder;
        }

        static async Task<Results<Ok<List<RespuestaUsuarioDTO>>, NotFound>> ObtenerUsuarios(IUsuarioHandler handler)
        {
            var usuariosDTO = await handler.ObtenerUsuarios();

            if (usuariosDTO is null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(usuariosDTO);
        }

        static async Task<Results<Ok<RespuestaUsuarioDTO>, NotFound>> ObtenerUsuario(IUsuarioHandler handler,
                                                                            string id)
        {
            var usuarioDTO = await handler.ObtenerUsuario(id);

            if (usuarioDTO is null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(usuarioDTO);
        }

        static async Task<Results<Created<RespuestaUsuarioDTO>, BadRequest<string>>> CrearUsuario(IUsuarioHandler handler,
                                                                                                  [FromBody] CrearUsuarioDTO usuarioDTO)
        {
            try
            {
                var usuarioCreado = await handler.CrearUsuario(usuarioDTO);

                return TypedResults.Created($"/api/usuarios/{usuarioCreado.Id}", usuarioCreado);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        static async Task<Results<NoContent, BadRequest<string>>> ActualizarUsuario(IUsuarioHandler handler,
                                                                                    [FromBody] ActualizarUsuarioDTO usuarioDTO)
        {
            try
            {
                var resultado = await handler.ActualizarUsuario(usuarioDTO);

                if (resultado)
                {
                    return TypedResults.NoContent();
                }
                else
                {
                    return TypedResults.BadRequest("No se pudo actualizar el usuario");
                }
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        static async Task<Results<NoContent, BadRequest<string>>> EliminarUsuario(IUsuarioHandler handler,
                                                                                  [FromBody] EliminarUsuarioDTO usuarioDTO)
        {
            try
            {
                var resultado = await handler.EliminarUsuario(usuarioDTO);

                if (resultado)
                {
                    return TypedResults.NoContent();
                }
                else
                {
                    return TypedResults.BadRequest("No se pudo eliminar el usuario");
                }
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
