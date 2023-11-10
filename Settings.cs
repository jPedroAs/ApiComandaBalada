using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace ApiBalada
{
    public static class Settings
    {
        public static string Secret = "NaoExiste1230123UmaChave32222Segreta123123";

        public static string ApiKeyName = "api_key";
        public static string ApiKey = "MandaBalaAiNaApi";

        public static string GenerateHash(string password)
        {
            byte[] salt = Encoding.ASCII.GetBytes("4546546546545");

            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 32));

            return hashed;
        }
    }
}
