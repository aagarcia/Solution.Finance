using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Solution.Finance.Application.Interfaces.Persistence;
using Solution.Finance.Domain.Entities;
using Solution.Finance.Persistence.Commons;
using System.Data;

namespace Solution.Finance.Persistence.Contexts
{
    public class UsuarioContext : IUsuarioContext
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UsuarioContext(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            var result = await _applicationDbContext.Usuarios.ToListAsync();

            return result;
        }

        public async Task<Usuario> ObtenerUsuario(string id)
        {
            Guid usuarioId = Guid.Parse(id);

            var result = await _applicationDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId);

            return result;
        }

        public async Task<string> CrearUsuario(Usuario usuario)
        {
            usuario.Created = Utilidades.GetEcuadorTime();

            var idParam = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Direction = ParameterDirection.Output
            };

            await _applicationDbContext.Context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.InsertUser @Nombre, @Apellido, @Estado, @CreatedBy, @Created, @Id OUTPUT",
                    new SqlParameter("@Nombre", usuario.Nombre),
                    new SqlParameter("@Apellido", usuario.Apellido),
                    new SqlParameter("@Estado", usuario.Estado),
                    new SqlParameter("@CreatedBy", usuario.CreatedBy),
                    new SqlParameter("@Created", usuario.Created),
                    idParam
            );

            return idParam.Value.ToString();
        }

        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            usuario.Updated = Utilidades.GetEcuadorTime();

            var respuesta = await _applicationDbContext.Context.Database.ExecuteSqlRawAsync(
                                "EXEC dbo.UpdateUser @Id, @Nombre, @Apellido, @Updated, @UpdatedBy",
                                    new SqlParameter("@Id", usuario.Id),
                                    new SqlParameter("@Nombre", usuario.Nombre),
                                    new SqlParameter("@Apellido", usuario.Apellido),
                                    new SqlParameter("@Updated", usuario.Updated),
                                    new SqlParameter("@UpdatedBy", usuario.UpdatedBy)
                            );

            if (respuesta == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EliminarUsuario(Usuario usuario)
        {
            usuario.Deleted = Utilidades.GetEcuadorTime();

            var respuesta = await _applicationDbContext.Context.Database.ExecuteSqlRawAsync(
                                "EXEC dbo.DeleteUser @Id, @Deleted, @DeletedBy",
                                    new SqlParameter("@Id", usuario.Id),
                                    new SqlParameter("@Deleted", usuario.Deleted),
                                    new SqlParameter("@DeletedBy", usuario.DeletedBy)
                            );

            if (respuesta == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
