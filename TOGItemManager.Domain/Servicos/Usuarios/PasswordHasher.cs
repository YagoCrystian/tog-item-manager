using TOGItemManager.Domain.Servicos.Usuarios.Interfaces;

namespace TOGItemManager.Domain.Servicos.Usuarios
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool Verificar(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}