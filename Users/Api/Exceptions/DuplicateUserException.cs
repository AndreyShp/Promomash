using System;

namespace Promomash.Users.WebApi.Exceptions {
    /// <summary>
    /// Исключение при дублировании пользователей
    /// </summary>
    internal class DuplicateUserException : Exception {
        /// <inheritdoc />
        public DuplicateUserException(string message) : base(message) { }
    }
}