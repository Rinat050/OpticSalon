namespace OpticSalon.Auth.Models
{
    public static class Role
    {
        public const string Client = "Клиент";
        public const string Master = "Мастер";
        public const string Manager = "Менеджер";
        public const string Admin = "Администратор";

        public static List<string> GetEmployeeRoles()
        {
            return new List<string>()
            {
                Manager, Admin, Master
            };
        }
    }
}