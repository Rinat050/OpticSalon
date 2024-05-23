﻿namespace OpticSalon.Auth.ResultMessages
{
    public static class AuthResults
    {
        public const string NotFounded = "Пользователь не найден!";
        public const string InvalidCurrentPassword = "Неправильно указан текущий пароль!";
        public const string SuccessPasswordUpdate = "Пароль успешно обновлен!";
        public const string SuccessRoleUpdate = "Роль сотрудника успешно обновлена!";
        public const string SuccessRegister = "Успешная регистрация!";
        public const string DefaultError = "Произошла ошибка!";
        public const string UserWithEmailExist = "Пользователь с указанной почтой уже зарегистрирован!";
        public const string SuccessEmailUpdate = "Адрес электронной почты успешно обновлен!";
        public const string InvalidRole = "Неопределена роль!";
    }
}
