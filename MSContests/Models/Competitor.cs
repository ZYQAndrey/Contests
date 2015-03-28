using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSContests.Models
{
    public class Competitor
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Фамилия")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Имя")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [EmailAddress(ErrorMessage = "Неверный адрес эл.почты")]
        [Display(Name = "Е-mail")]
        public virtual string Email { get; set; }

        [Phone(ErrorMessage = "Неверный номер телефона")]
        [Display(Name = "Phone")]
        public virtual string Phone { get; set; }

        [Display(Name = "Страна")]
        public virtual string Country { get; set; }

        [Display(Name = "Город")]
        public virtual string City { get; set; }

        [Display(Name = "Профессия (если работаете)")]
        public virtual string Position { get; set; }

        [Display(Name = "Студент")]
        public virtual bool AreYouAStudent { get; set; }
    }
}