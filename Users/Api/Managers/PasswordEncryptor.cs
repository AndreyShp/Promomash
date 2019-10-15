using System.Security.Cryptography;
using System.Text;
using Promomash.Users.Contracts.Data;
using Promomash.Users.WebApi.Managers.Contracts;

namespace Promomash.Users.WebApi.Managers {
    /// <summary>
    /// Отвечает за шифрование паролей
    /// </summary>
    internal class PasswordEncryptor : IPasswordEncryptor {
        private readonly string _salt;
        private readonly int _countIterations;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="salt">соль</param>
        /// <param name="countIterations">кол-во итераций для шифровки пароля</param>
        public PasswordEncryptor(string salt, int countIterations) {
            _salt = salt;
            _countIterations = countIterations;
        }
        
        /// <inheritdoc />
        public string Encrypt(User user) {
            var md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes($"{user.Login}_{user.Password}_{_salt}");
            byte[] hash;
            int i = 0;
            do {
                hash = md5.ComputeHash(inputBytes);
                inputBytes = hash;
                i++;
            } while (i < _countIterations);

            StringBuilder sb = new StringBuilder();
            foreach (var ch in hash) {
                sb.Append(ch.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}