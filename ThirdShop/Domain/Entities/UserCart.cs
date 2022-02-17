using System;
using System.ComponentModel.DataAnnotations;

namespace ThirdShop.Domain.Entities
{
    public class UserCart : EntityBase
    {
        [Required(ErrorMessage = "Заполните название услуги")]
        [Display(Name = "Название услуги")]
        public override string Title { get; set; }

        [Display(Name = "Код Товара")]
        public override string ProductCode { get; set; }

        [Display(Name = "Цена")]
        public override double Price { get; set; }

        [Display(Name = "Мини картинка")]
        public override string MiniImagePath { get; set; }

        [Display(Name = "Id  Владельца корзины")]
        public override Guid guid { get; set; }

        [DataType(DataType.Time)]
        public  DateTime DateAdded { get; set; }
    }
}
