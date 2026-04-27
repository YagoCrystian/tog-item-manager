namespace TOGItemManager.Application.DTOs.Usuarios.Requests
{
    public class UsuarioUpdateRequest{
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int? PerfilId { get; set; }

    }
    

}