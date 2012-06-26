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
    public class CityWeatherInfo
    {
        public CityWeatherInfo() { }
        public string CityGuid { get; set; }
        public string CityName { get; set; }

        public string LastUpdateTime { get; set; }
        public string Humidity { get; set; }
        public string WindCondition { get; set; }

        public string TodayWeek { get; set; }
        public string TodayIcon { get; set; }
        public string TodayLow { get; set; }
        public string TodayHight { get; set; }
        public string TodayCondition { get; set; }

        public string TomorrowWeek { get; set; }
        public string TomorrowIcon { get; set; }
        public string TomorrowLow { get; set; }
        public string TomorrowHight { get; set; }
        public string TomorrowCondition { get; set; }

        public string HouTianCondition { get; set; }
        public string HouTianHight { get; set; }
        public string HouTianIcon { get; set; }
        public string HouTianLow { get; set; }
        public string HouTianWeek { get; set; }

        public string DaHouTianCondition { get; set; }
        public string DaHouTianHight { get; set; }
        public string DaHouTianIcon { get; set; }
        public string DaHouTianLow { get; set; }
        public string DaHouTianWeek { get; set; }
    }
}
