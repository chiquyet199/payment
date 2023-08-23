using static HotChocolate.ErrorCodes;
using System.Security.Cryptography;
using System.Text;

namespace CryptoService.Api
{
    public class Query
    {
        private const String SECRET_KEY = "a0f0e92a8ce745509d4fa384ebf634df7918c0d928d943ec98be92364d9e0aec07fb54aea3964d6fb19f223b4b7f18c40dd434f481c642f0a3041f810d7e8480c9d041cf796845059eb3e276156d5910b69d08fdcf914592bdf2839f1c7c13684aac1a800a784c75a83b2a9043e6ae8e8442ebcbd2194a3cb8f6fd93a31b8d23";

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
