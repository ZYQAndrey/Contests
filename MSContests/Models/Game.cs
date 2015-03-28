using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSContests.Models
{
    public class Game
    {
        [Key]
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Display(Name = "Дата регистрации заявки")]
        public virtual DateTime RegisterDate { get; set; }

        [Display(Name = "Дата одобрения заявки")]
        public virtual DateTime ApprovalDate { get; set; }

        public virtual bool Approved { get; set; }

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

        [Display(Name = "Конкурсант")]
        public virtual Competitor Competitor { get; set; }
    }
}