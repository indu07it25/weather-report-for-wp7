using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Weather
{
    public static class TimeTools
    {
        public static string GetDayorNight() 
        {
            int hour = DateTime.Now.Hour;
            if (hour > 6 && hour < 18)
            {
                return "Day";
            }
            else
            {
                return "Night";
            }
        }
    }
}
