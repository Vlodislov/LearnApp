using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace LearnApp.PageModels.Base
{
    public class ExtendedBindableObject : BindableObject
    {
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value; // Установка нового значения по ссылке старому
            OnPropertyChanged(propertyName); // Изменения свойства для отобращения на икране
            return true;
        }
    }
}
