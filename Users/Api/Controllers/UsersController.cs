using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Promomash.Users.Contracts;
using Promomash.Users.Contracts.Data;
using Promomash.Users.WebApi.Managers.Contracts;

namespace Promomash.Users.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase, IUsersApi {
        private readonly IUsersManager _usersManager;

        public UsersController(IUsersManager usersManager) {
            _usersManager = usersManager;
        }

        // GET api/users
        [HttpGet]
        public bool Get() {
            return true;
        }
        
        /// <inheritdoc />
        // POST api/users/add 
        //{
        //    "Login": "andrey@mail.bla",
        //    "Password": "123",
        //    "RegionId": 7
        //}
        [Route("~/api/users/add")] 
        [HttpPost]
        public async Task<User> Add([FromBody] User user) {
            if (user == null || user.Id != 0 || string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password) || user.RegionId <= 0) {
                throw new ArgumentException(
                    "Некорректные данные пользователя. Должны быть заполнены только login, password, regionId!",
                    nameof(user));
            }
            var result = await _usersManager.AddAsync(user);
            return result;
        }
    }
}