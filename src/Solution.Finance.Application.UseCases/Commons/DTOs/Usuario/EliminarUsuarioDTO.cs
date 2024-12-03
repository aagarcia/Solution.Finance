namespace Solution.Finance.Application.UseCases.Commons.DTOs.Usuario
{
    public sealed record EliminarUsuarioDTO
    {
        public Guid Id { get; set; }
        public string DeletedBy { get; set; }
    }
}
