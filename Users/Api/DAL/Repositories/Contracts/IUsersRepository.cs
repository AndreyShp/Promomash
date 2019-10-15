using System.Threading.Tasks;
using Promomash.Users.WebApi.DAL.Dto;

namespace Promomash.Users.WebApi.DAL.Repositories.Contracts {
    /// <summary>
    /// Интерфейс репозитория пользователей
    /// </summary>
    internal interface IUsersRepository {
        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="user">пользователь для добавления</param>
        /// <returns>добавленный пользователь</returns>
        Task<UserDto> AddAsync(UserDto user);
    }
}