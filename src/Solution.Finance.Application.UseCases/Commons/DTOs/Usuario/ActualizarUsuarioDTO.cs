namespace Solution.Finance.Application.UseCases.Commons.DTOs.Usuario
{
    public sealed record ActualizarUsuarioDTO
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string UpdatedBy { get; set; }
    }
}
