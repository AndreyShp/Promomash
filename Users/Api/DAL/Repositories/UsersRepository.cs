using Promomash.Common.DAL.Repositories;
using Promomash.Users.WebApi.DAL.Context;
using Promomash.Users.WebApi.DAL.Dto;
using Promomash.Users.WebApi.DAL.Repositories.Contracts;

namespace Promomash.Users.WebApi.DAL.Repositories {
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    internal class UsersRepository : RepositoryBase<UserDto>, IUsersRepository {
        /// <inheritdoc />
        public UsersRepository(UsersDbContext dbContext) : base(dbContext) { }
    }
}