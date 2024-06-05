using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Создан")] Created = 1,
        [Display(Name = "В работе")] InWork = 2,
        [Display(Name = "Готов")] Completed = 3,
        [Display(Name = "Выдан")] Issued = 4
    }
}
