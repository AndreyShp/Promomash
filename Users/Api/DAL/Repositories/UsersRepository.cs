using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Promomash.Common.DAL.Repositories;
using Promomash.Users.WebApi.DAL.Context;
using Promomash.Users.WebApi.DAL.Dto;
using Promomash.Users.WebApi.DAL.Repositories.Contracts;
using Promomash.Users.WebApi.Exceptions;

namespace Promomash.Users.WebApi.DAL.Repositories {
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    internal class UsersRepository : RepositoryBase<UserDto>, IUsersRepository {
        /// <inheritdoc />
        public UsersRepository(UsersDbContext dbContext) : base(dbContext) { }

        public override async Task<UserDto> AddAsync(UserDto user) {
            try {
                return await base.AddAsync(user);
            } catch (Exception e) {
                //пусть база отдохнет доверимся сообщению что такой пользователь уже существует
                if (e.InnerException is SqlException &&
                    e.InnerException.Message?.Contains("Cannot insert duplicate key row in object") == true) {
                    throw new DuplicateUserException("User with the same login already exists!");
                }
                throw;
            }
        }
    }
}