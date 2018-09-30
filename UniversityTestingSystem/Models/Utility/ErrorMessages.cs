using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityTestingSystem.Models.Utility
{
    public static class ErrorMessages
    {
        public const string StringLength255 = "Длина строки не должна превышать 255 знаков";
        public const string RequiredTextBox = "Это поле обязательно для заполнения";
        public const string RequiredComboBox = "Вам необходимо выбрать значение";
    }
}