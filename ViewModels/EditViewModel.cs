using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunter.ViewModels
{
    public class EditViewModel
    {
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }


        [EmailAddress(ErrorMessage = "Некорректный электронный адрес")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Аватар")]
        public string Avatar { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Тип пользователя")]
        public string Role { get; set; }
    }
}
