namespace Solution.Finance.Application.UseCases.Commons.DTOs.Usuario
{
    public sealed record RespuestaUsuarioDTO
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public bool Estado { get; set; }
    }
}
