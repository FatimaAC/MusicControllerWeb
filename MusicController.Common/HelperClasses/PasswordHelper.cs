namespace MusicController.Common.HelperClasses
{
    // encrpy Using BCrypt Nuget Library
    public static class PasswordHelper
    {
        public static string EncryptPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }
        public static bool VerifyPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}
