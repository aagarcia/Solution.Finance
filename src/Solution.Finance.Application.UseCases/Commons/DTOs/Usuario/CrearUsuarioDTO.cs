namespace Solution.Finance.Application.UseCases.Commons.DTOs.Usuario
{
    public sealed record CrearUsuarioDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Estado { get; set; }
        public string CreatedBy { get; set; }
    }
}
