
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OB.Data.Services
{
    public class AesCrypto
    {

        public AesOptions aesOptions { get; }

        public AesCrypto(IOptions<AesOptions> options) 
        {
            this.aesOptions = options.Value;
        }

        public string Encrypt(string data, string salt)
        {

            byte[] utfdata = UTF8Encoding.UTF8.GetBytes(data);
            byte[] saltBytes = UTF8Encoding.UTF8.GetBytes(salt);

            using (AesManaged aes = new AesManaged())
            {
                Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(aesOptions.AesPassword, saltBytes);

                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;
                aes.Key = rfc.GetBytes(aes.KeySize / 8);
                aes.IV = rfc.GetBytes(aes.BlockSize / 8);

                using (MemoryStream encryptStream = new MemoryStream())
                {
                    CryptoStream encryptor = new CryptoStream(encryptStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

                    encryptor.Write(utfdata, 0, utfdata.Length);
                    encryptor.Flush();
                    encryptor.Close();

                    return Convert.ToBase64String(encryptStream.ToArray());
                }
            }
        }

        public string Decrypt(string base64Input, string salt)
        {

            byte[] encryptBytes = Convert.FromBase64String(base64Input);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            using (AesManaged aes = new AesManaged())
            {
                Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(aesOptions.AesPassword, saltBytes);

                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;
                aes.Key = rfc.GetBytes(aes.KeySize / 8);
                aes.IV = rfc.GetBytes(aes.BlockSize / 8);

                using (MemoryStream decryptStream = new MemoryStream())
                {
                    CryptoStream decryptor = new CryptoStream(decryptStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

                    decryptor.Write(encryptBytes, 0, encryptBytes.Length);
                    decryptor.Flush();
                    decryptor.Close();

                    byte[] decryptBytes = decryptStream.ToArray();
                    return UTF8Encoding.UTF8.GetString(decryptBytes, 0, decryptBytes.Length);
                }
            }
        }
    }


    ///--------------------------------------------
    public class AesOptions
    {
        public string AesPassword { get; set; }
    }
}