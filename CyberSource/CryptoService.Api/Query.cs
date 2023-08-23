using static HotChocolate.ErrorCodes;
using System.Security.Cryptography;
using System.Text;

namespace CryptoService.Api
{
    public class Query
    {
        private const String SECRET_KEY = "6ca5231b676a48359247ccd931d47211ee29cba4202647469f2feb7400c5e2460721f523d81641ff9f4deed5ed1f8c5370fef6927b1b499a89789f8bf3ee78b466ee175a8a2b4cc59c50c205c540e9365433ee4bfb8e419e8df0ad678b6969ddfecbe114daaa498381a99478518ec9c20de8fa80d51b44c29b6125e51e23f143";

        public string GetHmacSha256(string message)
        {
            UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(SECRET_KEY);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(message);
            return Convert.ToBase64String(hmacsha256.ComputeHash(messageBytes));
        }
    }
}
