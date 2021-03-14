using RepairAirplanesWPF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RepairAirplanesWPF.Converters
{
    public class PermissionCheckConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*if (value is Person person)
            {
                if (parameter is string stringValue)
                {
                    var result1 = person.Permission_group.Permission_for_group.Permission.FirstOrDefault((perm) => perm.name.Trim().ToLower() == stringValue.Trim().ToLower()) != default(Permission);
                    return result1 ? Visibility.Visible : Visibility.Collapsed;
                }
            }*/
            return Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}