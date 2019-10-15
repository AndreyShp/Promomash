using System.Threading.Tasks;
using AutoMapper;
using Promomash.Users.Contracts.Data;
using Promomash.Users.WebApi.DAL.Dto;
using Promomash.Users.WebApi.DAL.Repositories.Contracts;
using Promomash.Users.WebApi.Managers.Contracts;

namespace Promomash.Users.WebApi.Managers {
    /// <summary>
    /// Менеджер для работы с пользователями
    /// </summary>
    internal class UsersManager : IUsersManager {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordEncryptor _passwordEncryptor;

        public UsersManager(IUsersRepository usersRepository, IPasswordEncryptor passwordEncryptor, IMapper mapper) {
            _usersRepository = usersRepository;
            _passwordEncryptor = passwordEncryptor;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<User> AddAsync(User user) {
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Password = _passwordEncryptor.Encrypt(user);
            var addedUser = await _usersRepository.AddAsync(userDto);
            
            var result = _mapper.Map<User>(addedUser);
            return result;
        }
    }
}