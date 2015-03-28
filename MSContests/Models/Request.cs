using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MSContests.Models
{
    public class Request
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

        [Required (ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название приложения")]
        public virtual string AppName { get; set; }

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

        [Display(Name = "Страна")]
        public virtual string Country { get; set; }

        [Display(Name = "Город")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Должность")]
        public virtual string Position { get; set; }

        [Display(Name = "Являетесь ли студентом")]
        public virtual bool AreYouAStudent { get; set; }

        //[Required(ErrorMessage = "Обязательное поле")] //ALTER TABLE [dbo].[Requests] ALTER COLUMN [AppUrl] nvarchar(max) NULL
        [Display(Name = "Адрес в WINDOWS STORE")]
        public virtual string AppUrl { get; set; }

        [Display(Name = "Это приложение Windows 8")]
        public virtual bool Windows8App { get; set; }

        [Display(Name = "Ссылка на демо")]
        public virtual string DemoUrl { get; set; }

        [Display(Name = "Комментарии")]
        public virtual string Comments { get; set; }

        //[Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Адрес в Windows Phone Store")]
        public virtual string WPhoneAppUrl { get; set; }

        [Display(Name = "Это приложение Windows Phone 8")]
        public virtual bool WPhone8App { get; set; }

        [Display(Name = "Приложение использует Windows Azure")]
        public virtual bool WAzureApp { get; set; }
    }
}