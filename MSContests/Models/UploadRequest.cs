using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSContests.Models
{
    public class UploadRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Display(Name = "Дата регистрации заявки")]
        public virtual DateTime RegisterDate { get; set; }

        [Display(Name = "Дата одобрения заявки")]
        public virtual DateTime ApprovalDate { get; set; }

        public virtual bool Approved { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Фамилия")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Имя")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$", ErrorMessage = "Введите корректный адрес эл.почты")] 
        [Display(Name = "Е-mail")]
        public virtual string Email { get; set; }

        [Display(Name = "Город")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Должность")]
        public virtual string Position { get; set; }  

        [Display(Name = "Комментарии")]
        public virtual string Comments { get; set; }

        [Display(Name = "Пакет Windows 8 приложения")]
        public byte[] FileW8 { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string FileW8MimeType { get; set; }

        [Display(Name = "Пакет Windows Phone приложения")]
        public byte[] FileWp8 { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string FileWp8MimeType { get; set; }

    }
}