namespace Promomash.Users.Contracts.Data {
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User {
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
        /// Регион пользователя
        /// </summary>
        public long RegionId { get; set; }
    }
}