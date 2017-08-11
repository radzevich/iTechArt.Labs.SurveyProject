using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace SinglePageApp.Providers
{
    public class Encryptor
    {
        public string Encrypt(object instanceToEncrypt)
        {
            var toBinaryArrayFormatter = new BinaryFormatter();

            using (var stream = new MemoryStream())
            {
                toBinaryArrayFormatter.Serialize(stream, instanceToEncrypt);

                var sha = new SHA1CryptoServiceProvider();
                var byteArrayToEncrypt = stream.ToArray();          
                var encryptedByteArray = sha.ComputeHash(byteArrayToEncrypt);

                return System.Text.Encoding.UTF8.GetString(encryptedByteArray);
            }
        }
    }
}