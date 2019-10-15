using System.Threading.Tasks;
using Promomash.Users.Contracts.Data;

namespace Promomash.Users.WebApi.Managers.Contracts {
    /// <summary>
    /// Интерфейс менеджера пользователей
    /// </summary>
    public interface IUsersManager {
        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="user">пользователь для добавления</param>
        /// <returns>пользователь (с затертым паролем)</returns>
        Task<User> AddAsync(User user);
    }
}