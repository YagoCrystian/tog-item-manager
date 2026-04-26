namespace TOGItemManager.Application.Seguranca
{
    public static class PasswordHasher
    {
        public static string Hash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool Verificar(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}