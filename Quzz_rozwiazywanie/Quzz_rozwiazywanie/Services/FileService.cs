using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Quzz_rozwiazywanie.Models;

namespace Quzz_rozwiazywanie.Services
{
    public class FileService
    {
        private readonly string _key;
        private readonly string _iv;

        public FileService()
        {
            _key = "YourSecretKey1234567890123456789012"; // 32 bajty dla AES-256
            _iv = "YourInitVector12"; // 16 bajtów
        }

        public async Task<Quiz> LoadQuizAsync(string filePath)
        {
            try
            {
                byte[] encryptedData = await File.ReadAllBytesAsync(filePath);
                byte[] decryptedData = DecryptData(encryptedData);
                string json = Encoding.UTF8.GetString(decryptedData);
                return JsonSerializer.Deserialize<Quiz>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Błąd podczas wczytywania quizu", ex);
            }
        }

        private byte[] DecryptData(byte[] encryptedData)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = Encoding.UTF8.GetBytes(_iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedData, 0, encryptedData.Length);
                        cs.FlushFinalBlock();
                    }
                    return ms.ToArray();
                }
            }
        }
    }
}