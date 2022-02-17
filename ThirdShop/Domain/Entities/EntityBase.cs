using System;
using System.ComponentModel.DataAnnotations;

namespace ThirdShop.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название (заголовок)")]
        public virtual string Title { get; set; }

        [Display(Name = "Подзаголовок")]
        public virtual string Undertitle { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "Мини картинка")]
        public virtual string MiniImagePath { get; set; }

        [Display(Name = "Код товара")]
        public virtual string ProductCode { get; set; }

        [Display(Name = "Товар в корзине")]
        public virtual bool IsinCart { get; set; }

        [Display(Name = "Цена")]
        public virtual double Price { get; set; }

        [Display(Name = "Id  Владельца корзины")]
        public virtual Guid guid { get; set; }

        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO метатег Description")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO метатег Keywords")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }


}

