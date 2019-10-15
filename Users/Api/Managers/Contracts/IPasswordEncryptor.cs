using Promomash.Users.Contracts.Data;

namespace Promomash.Users.WebApi.Managers.Contracts {
    /// <summary>
    /// Интерфейс шифровщика паролей
    /// </summary>
    internal interface IPasswordEncryptor {
        /// <summary>
        /// Возвращает зашифрованный пароль на основе данных пользователя
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <returns>зашифрованный пароль</returns>
        string Encrypt(User user);
    }
}