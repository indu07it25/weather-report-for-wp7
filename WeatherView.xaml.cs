using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
namespace Weather
{
    public partial class WeatherView : PhoneApplicationPage
    {
        List<CityWeatherInfo> citys = new List<CityWeatherInfo>();
        public WeatherView()
        {
            InitializeComponent();
            citys = IsolatedStorageSettings.ApplicationSettings["City"] as List<CityWeatherInfo>;
        }
        string cityName = "济南";
        string TodayIcon = "";
        string TodayInfo = "未知";
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("cityName"))
            {
                cityName = NavigationContext.QueryString["cityName"];
            }
            BingUI();
            BingData();
        }
        string DayOrNight;
        private void BingData() 
        {
            foreach (var item in citys)
            {
                if (item.CityName==cityName)
                {
                    imgWeather.Source = new BitmapImage(new Uri("/Images/Weathericon/" + DayOrNight + "/" + item.TodayIcon + ".png", UriKind.RelativeOrAbsolute));

                    txtTodayTemperature.Text = item.TodayLow + "℃～" + item.TodayHight + "℃";
                    txtCityName.Text = item.CityName;
                    txtLastUpdateTime.Text = item.LastUpdateTime;
                    TodayInfo = item.TodayCondition;
                    txtTodayInfo.Text = "今日天气实况：" + item.TodayCondition + "；气温:" + txtTodayTemperature.Text + "；" + item.WindCondition + "；" + item.Humidity;
                    TodayIcon = item.TodayIcon;
                    forecastTile1.WhichDay = item.TodayWeek;
                    forecastTile1.Weathericon = new BitmapImage(new Uri("/Images/Forecasts/" + DayOrNight + "/" + item.TodayIcon + ".png", UriKind.RelativeOrAbsolute));
                    forecastTile1.Temperature = item.TodayLow + "°/" + item.TodayHight + "°";

                    forecastTile2.WhichDay = item.TomorrowWeek;
                    forecastTile2.Weathericon = new BitmapImage(new Uri("/Images/Forecasts/" + DayOrNight + "/" + item.TomorrowIcon + ".png", UriKind.RelativeOrAbsolute));
                    forecastTile2.Temperature = item.TomorrowLow + "°/" + item.TomorrowHight + "°";

                    forecastTile3.WhichDay = item.HouTianWeek;
                    forecastTile3.Weathericon = new BitmapImage(new Uri("/Images/Forecasts/" + DayOrNight + "/" + item.HouTianIcon + ".png", UriKind.RelativeOrAbsolute));
                    forecastTile3.Temperature = item.HouTianLow + "°/" + item.HouTianHight + "°";

                    forecastTile4.WhichDay = item.DaHouTianWeek;
                    forecastTile4.Weathericon = new BitmapImage(new Uri("/Images/Forecasts/" + DayOrNight + "/" + item.DaHouTianIcon + ".png", UriKind.RelativeOrAbsolute));
                    forecastTile4.Temperature = item.DaHouTianLow + "°/" + item.DaHouTianHight + "°";
                }
            }
        }

        private void BingUI() 
        {
            int hour = DateTime.Now.Hour;
            ImageBrush img = new ImageBrush();
            DayOrNight = TimeTools.GetDayorNight();
            img.ImageSource = new BitmapImage(new Uri("/Images/Back/"+DayOrNight+".jpg", UriKind.RelativeOrAbsolute));
            LayoutRoot.Background = img;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            base.OnBackKeyPress(e);
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            ChangeTile.ChangeTileByCityName(cityName, TodayIcon, TodayInfo, txtTodayTemperature.Text);
        }
    }
}