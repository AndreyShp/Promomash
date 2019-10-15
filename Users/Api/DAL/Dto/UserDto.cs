namespace Promomash.Users.WebApi.DAL.Dto {
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserDto {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Идентификатор региона
        /// </summary>
        public long RegionId { get; set; }
    }
}