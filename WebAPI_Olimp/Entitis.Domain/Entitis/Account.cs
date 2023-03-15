/*Модель пользователя*/

namespace Models.Entitis
{
    public class Account
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}