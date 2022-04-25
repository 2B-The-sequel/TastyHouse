using System;
using System.Windows.Data;
using FoodMenuUtility.Models;

namespace AdminApp.KigIkkeHer
{
    [ValueConversion(typeof(OrderState), typeof(string))]
    public class AcceptationStatusGlobalFlagToIconFilenameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (OrderState)value switch
            {
                OrderState.Accepted => "/Resources/Accept.png",
                OrderState.Declined => "/Resources/Decline.png",
                OrderState.Awaiting => "/Resources/Question.png",
                OrderState.Done => "/Resources/Done.png",
                _ => null,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}