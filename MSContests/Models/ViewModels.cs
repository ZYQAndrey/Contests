using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSContests.Models
{
    public class UniversalAppViewModel
    {
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
        [Display(Name = "Телефон")]
        public virtual string Phone { get; set; }

        [Display(Name = "Страна")]
        public virtual string Country { get; set; }

        [Display(Name = "Город")]
        public virtual string City { get; set; }

        [Display(Name = "Профессия (если работаете)")]
        public virtual string Position { get; set; }

        [Display(Name = "Студент")]
        public virtual bool AreYouAStudent { get; set; }


        
        
        [Display(Name = "Дата регистрации заявки")]
        public virtual DateTime RegisterDate { get; set; }

        [Display(Name = "Дата одобрения заявки")]
        public virtual DateTime ApprovalDate { get; set; }

        public virtual bool Approved { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название приложения в Windows Store")]
        public virtual string W8AppName { get; set; }

        [Display(Name = "Адрес в Windows Store")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string W8AppUrl { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название приложения в Windows Phone Store")]
        public virtual string WpAppName { get; set; }

        [Display(Name = "Адрес в Windows Phone Store")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string WpAppUrl { get; set; }

        [Display(Name = "Комментарии (если требуются)")]
        public virtual string Comments { get; set; }
    }
    public class UniversalAppDetailsViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Одобрено")]
        public virtual bool Approved { get; set; }

        [Display(Name = "Дата регистрации заявки")]
        public virtual DateTime RegisterDate { get; set; }

        [Display(Name = "Дата одобрения заявки")]
        public virtual DateTime ApprovalDate { get; set; }

        [Display(Name = "Фамилия")]
        public virtual string LastName { get; set; }

        [Display(Name = "Имя")]
        public virtual string FirstName { get; set; }

        [EmailAddress(ErrorMessage = "Неверный адрес эл.почты")]
        [Display(Name = "Е-mail")]
        public virtual string Email { get; set; }

        [Display(Name = "Телефон")]
        public virtual string Phone { get; set; }

        [Display(Name = "Страна")]
        public virtual string Country { get; set; }

        [Display(Name = "Город")]
        public virtual string City { get; set; }

        [Display(Name = "Профессия (если работаете)")]
        public virtual string Position { get; set; }

        [Display(Name = "Студент")]
        public virtual bool AreYouAStudent { get; set; }



        [Display(Name = "Название приложения в Windows Store")]
        public virtual string W8AppName { get; set; }

        [Display(Name = "Адрес в Windows Store")]
        public virtual string W8AppUrl { get; set; }

        [Display(Name = "Название приложения в Windows Phone Store")]
        public virtual string WpAppName { get; set; }

        [Display(Name = "Адрес в Windows Phone Store")]
        public virtual string WpAppUrl { get; set; }

        [Display(Name = "Комментарии (если требуются)")]
        public virtual string Comments { get; set; }
    }
    public class UniversalEditAppViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название приложения в Windows Store")]
        public virtual string W8AppName { get; set; }

        [Display(Name = "Название приложения в Windows Phone Store")]
        public virtual string WpAppName { get; set; }

        [Display(Name = "Одобрено")]
        public virtual bool Approved { get; set; }
    }

    public class UniversalListViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Одобрено")]
        public virtual bool Approved { get; set; }

        [Display(Name = "Дата регистрации заявки")]
        public virtual DateTime RegisterDate { get; set; }

        [Display(Name = "Название приложения")]
        public virtual string W8AppName { get; set; }
    }

    public class MultiPlatformAppViewModel
    {
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
        [Display(Name = "Телефон")]
        public virtual string Phone { get; set; }

        [Display(Name = "Страна")]
        public virtual string Country { get; set; }

        [Display(Name = "Город")]
        public virtual string City { get; set; }

        [Display(Name = "Профессия (если работаете)")]
        public virtual string Position { get; set; }

        [Display(Name = "Студент")]
        public virtual bool AreYouAStudent { get; set; }


        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название приложения в Windows Store")]
        public virtual string W8AppName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Адрес в Windows Store")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string W8AppUrl { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название приложения в Windows Phone Store")]
        public virtual string WpAppName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Адрес в Windows Phone Store")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string WpAppUrl { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название приложения в App Store")]
        public virtual string AppleAppName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Адрес в App Store")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string AppleAppUrl { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название приложения в Google Play")]
        public virtual string GoogleAppName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Адрес в Google Play")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string GoogleAppUrl { get; set; }

        [Display(Name = "Комментарии (если требуются)")]
        public virtual string Comments { get; set; }
    }

    public class MultiplePlutformAppDetailsViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Одобрено")]
        public virtual bool Approved { get; set; }

        [Display(Name = "Дата регистрации заявки")]
        public virtual DateTime RegisterDate { get; set; }

        [Display(Name = "Дата одобрения заявки")]
        public virtual DateTime ApprovalDate { get; set; }

        [Display(Name = "Фамилия")]
        public virtual string LastName { get; set; }

        [Display(Name = "Имя")]
        public virtual string FirstName { get; set; }

        [EmailAddress(ErrorMessage = "Неверный адрес эл.почты")]
        [Display(Name = "Е-mail")]
        public virtual string Email { get; set; }

        [Display(Name = "Телефон")]
        public virtual string Phone { get; set; }

        [Display(Name = "Страна")]
        public virtual string Country { get; set; }

        [Display(Name = "Город")]
        public virtual string City { get; set; }

        [Display(Name = "Профессия (если работаете)")]
        public virtual string Position { get; set; }

        [Display(Name = "Студент")]
        public virtual bool AreYouAStudent { get; set; }



        [Display(Name = "Название приложения в Windows Store")]
        public virtual string W8AppName { get; set; }

        [Display(Name = "Адрес в Windows Store")]
        public virtual string W8AppUrl { get; set; }

        [Display(Name = "Название приложения в Windows Phone Store")]
        public virtual string WpAppName { get; set; }

        [Display(Name = "Адрес в Windows Phone Store")]
        public virtual string WpAppUrl { get; set; }

        [Display(Name = "Название приложения в App Store")]
        public virtual string AppleAppName { get; set; }

        [Display(Name = "Адрес в App Store")]
        public virtual string AppleAppUrl { get; set; }

        [Display(Name = "Название приложения в Google Play")]
        public virtual string GoogleAppName { get; set; }

        [Display(Name = "Адрес в Google Play")]
        public virtual string GoogleAppUrl { get; set; }

        [Display(Name = "Комментарии (если требуются)")]
        public virtual string Comments { get; set; }
    }
    public class MultiPlatformEditAppViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название приложения в Windows Store")]
        public virtual string W8AppName { get; set; }

        [Display(Name = "Название приложения в Windows Phone Store")]
        public virtual string WpAppName { get; set; }

        [Display(Name = "Название приложения в App Store")]
        public virtual string AppleAppName { get; set; }

        [Display(Name = "Название приложения в Google Play")]
        public virtual string GoogleAppName { get; set; }

        [Display(Name="Одобрено")]
        public virtual bool Approved { get; set; }
    }

    public class MultiPlatformListViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Одобрено")]
        public virtual bool Approved { get; set; }

        [Display(Name = "Дата регистрации заявки")]
        public virtual DateTime RegisterDate { get; set; }

        [Display(Name = "Название приложения")]
        public virtual string W8AppName { get; set; }
    }

    public class GameViewModel
    {
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
        [Display(Name = "Телефон")]
        public virtual string Phone { get; set; }

        [Display(Name = "Страна")]
        public virtual string Country { get; set; }

        [Display(Name = "Город")]
        public virtual string City { get; set; }

        [Display(Name = "Профессия (если работаете)")]
        public virtual string Position { get; set; }

        [Display(Name = "Студент")]
        public virtual bool AreYouAStudent { get; set; }


        
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название игры в Windows Phone Store")]
        public virtual string WpAppName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Адрес в Windows Phone Store")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string WpAppUrl { get; set; }

        [Display(Name = "Название игры в Windows Store")]
        public virtual string W8AppName { get; set; }

        [Display(Name = "Адрес в Windows Store")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string W8AppUrl { get; set; }

        [Display(Name = "Название игры в Xbox Store")]
        public virtual string XboxAppName { get; set; }

        [Display(Name = "Адрес в Xbox Store")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string XboxAppUrl { get; set; }

        [Display(Name = "Название игры в App Store")]
        public virtual string AppleAppName { get; set; }

        [Display(Name = "Адрес в App Store")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string AppleAppUrl { get; set; }

        [Display(Name = "Название игры в Google Play")]
        public virtual string GoogleAppName { get; set; }

        [Display(Name = "Адрес в Google Play")]
        [Url(ErrorMessage = "Неверный URL")]
        public virtual string GoogleAppUrl { get; set; }

        [Display(Name = "Комментарии (если требуются)")]
        public virtual string Comments { get; set; }
    }

    public class GameDetailViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Одобрено")]
        public virtual bool Approved { get; set; }

        [Display(Name = "Дата регистрации заявки")]
        public virtual DateTime RegisterDate { get; set; }

        [Display(Name = "Дата одобрения заявки")]
        public virtual DateTime ApprovalDate { get; set; }

        [Display(Name = "Фамилия")]
        public virtual string LastName { get; set; }

        [Display(Name = "Имя")]
        public virtual string FirstName { get; set; }

        [EmailAddress(ErrorMessage = "Неверный адрес эл.почты")]
        [Display(Name = "Е-mail")]
        public virtual string Email { get; set; }

        [Display(Name = "Телефон")]
        public virtual string Phone { get; set; }

        [Display(Name = "Страна")]
        public virtual string Country { get; set; }

        [Display(Name = "Город")]
        public virtual string City { get; set; }

        [Display(Name = "Профессия (если работаете)")]
        public virtual string Position { get; set; }

        [Display(Name = "Студент")]
        public virtual bool AreYouAStudent { get; set; }



        [Display(Name = "Название игры в Windows Phone Store")]
        public virtual string WpAppName { get; set; }

        [Display(Name = "Адрес в Windows Phone Store")]
        public virtual string WpAppUrl { get; set; }

        [Display(Name = "Название игры в Windows Store")]
        public virtual string W8AppName { get; set; }

        [Display(Name = "Адрес в Windows Store")]
        public virtual string W8AppUrl { get; set; }

        [Display(Name = "Название игры в Xbox Store")]
        public virtual string XboxAppName { get; set; }

        [Display(Name = "Адрес в Xbox Store")]
        public virtual string XboxAppUrl { get; set; }

        [Display(Name = "Название игры в App Store")]
        public virtual string AppleAppName { get; set; }

        [Display(Name = "Адрес в App Store")]
        public virtual string AppleAppUrl { get; set; }

        [Display(Name = "Название игры в Google Play")]
        public virtual string GoogleAppName { get; set; }

        [Display(Name = "Адрес в Google Play")]
        public virtual string GoogleAppUrl { get; set; }

        [Display(Name = "Комментарии")]
        public virtual string Comments { get; set; }
    }

    public class GameEditViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название игры в Windows Phone Store")]
        public virtual string WpAppName { get; set; }

        [Display(Name = "Название игры в Windows Store")]
        public virtual string W8AppName { get; set; }

        [Display(Name = "Название игры в Xbox Store")]
        public virtual string XboxAppName { get; set; }

        [Display(Name = "Название игры в App Store")]
        public virtual string AppleAppName { get; set; }

        [Display(Name = "Название игры в Google Play")]
        public virtual string GoogleAppName { get; set; }

        [Display(Name = "Одобрено")]
        public virtual bool Approved { get; set; }
    }

    public class GameListViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Одобрено")]
        public virtual bool Approved { get; set; }

        [Display(Name = "Дата регистрации заявки")]
        public virtual DateTime RegisterDate { get; set; }

        [Display(Name = "Название игры")]
        public virtual string AppName { get; set; }
    }
}