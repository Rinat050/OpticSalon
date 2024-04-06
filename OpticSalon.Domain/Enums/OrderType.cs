using System.ComponentModel.DataAnnotations;

namespace OpticSalon.Domain.Enums
{
    public enum OrderType
    {
        [Display(Name = "Заказ на изготовление")] ManufactureOrder = 1,
        [Display(Name = "Гарантийный ремонт")] WarrantyRepair = 2
    }
}
