using System.Collections.Generic;
using System.Threading.Tasks;
using Promomash.Users.Contracts.Data;

namespace Promomash.Users.Contracts {
    /// <summary>
    /// Интерфейс сервиса пользователей
    /// </summary>
    public interface IUsersApi {
        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="user">пользователь для добавления</param>
        /// <returns>если добавлен то пользователь с идентификатором, но без пароля</returns>
        Task<User> Add(User user);
    }
}