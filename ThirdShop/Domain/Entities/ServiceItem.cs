using System;
using System.ComponentModel.DataAnnotations;

namespace ThirdShop.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название услуги")]
        [Display(Name = "Название услуги")]
        public override string Title { get; set; }
        [Display(Name = "Под название услуги")]
        public override string Undertitle { get; set; }

        [Display(Name = "Краткое описание услуги")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание услуги")]
        public override string Text { get; set; }

        [Display(Name = "Код Товара")] 
        public override string ProductCode { get; set; }

        [Display(Name = "Цена")]
        public override double Price { get; set; }

        [Display(Name = "Товар в корзине")]
        public override bool IsinCart { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
