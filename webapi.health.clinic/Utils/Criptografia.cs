namespace webapi.health.clinic.Utils
{
    public static class Criptografia
    {
        public static string GerarHash(string senha)
            => BCrypt.Net.BCrypt.HashPassword(senha);

        public static bool CompararHash(string senhaForm, string senhaHash)
            => BCrypt.Net.BCrypt.Verify(senhaForm, senhaHash);
    }
}
