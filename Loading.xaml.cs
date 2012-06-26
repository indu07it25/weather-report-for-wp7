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
using GoogleWeather;
using System.Xml.Linq;
namespace Weather
{
    public partial class Loading : PhoneApplicationPage
    {
        List<CityWeatherInfo> citys = new List<CityWeatherInfo>();
        WebClient client = new WebClient();
        string cityName = "济南";
        public Loading()
        {
            InitializeComponent();
            citys = IsolatedStorageSettings.ApplicationSettings["City"] as List<CityWeatherInfo>;
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingData();
        }
        string AndGoPage = "MainPage";
        public void LoadingData()
        {
            AndGoPage = NavigationContext.QueryString["AndGoPage"];
            if (NavigationContext.QueryString.ContainsKey("cityName"))
            {
                cityName = NavigationContext.QueryString["cityName"];
            }
            client.OpenReadAsync(new Uri("http://www.google.com/ig/api?hl=zh-cn&oe=utf8&weather=" + cityName, UriKind.RelativeOrAbsolute));
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
        }

        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            XElement xmlWeather;
            try
            {
                xmlWeather = XElement.Load(e.Result);
            }
            catch (Exception)
            {
                MessageBox.Show("获取城市信息失败");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
                return;
            }
            foreach (var item in citys)
            {
                if (item.CityName == cityName)
                {
                    item.TodayIcon = GoogleWeatherHelper.GetTodayIcon(xmlWeather);
                    item.LastUpdateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    item.Humidity = GoogleWeatherHelper.GetHumidity(xmlWeather);
                    try
                    {
                        item.WindCondition = GoogleWeatherHelper.GetWindCondition(xmlWeather);
                    }
                    catch (Exception)
                    {
                        item.WindCondition = "未知";
                    }
                    item.TodayWeek = GoogleWeatherHelper.GetTodayWeek(xmlWeather);
                    item.TodayIcon = GoogleWeatherHelper.GetTodayIcon(xmlWeather);
                    item.TodayLow = GoogleWeatherHelper.GetTodayLow(xmlWeather);
                    item.TodayHight = GoogleWeatherHelper.GetTodayHight(xmlWeather);
                    item.TodayCondition = GoogleWeatherHelper.GetTodayCondition(xmlWeather);

                    item.TomorrowWeek = GoogleWeatherHelper.GetTomorrowWeek(xmlWeather);
                    item.TomorrowIcon = GoogleWeatherHelper.GetTomorrowIcon(xmlWeather);
                    item.TomorrowLow = GoogleWeatherHelper.GetTomorrowLow(xmlWeather);
                    item.TomorrowHight = GoogleWeatherHelper.GetTomorrowHight(xmlWeather);
                    item.TomorrowCondition = GoogleWeatherHelper.GetTomorrowCondition(xmlWeather);

                    item.HouTianWeek = GoogleWeatherHelper.GetHouTianWeek(xmlWeather);
                    item.HouTianIcon = GoogleWeatherHelper.GetHouTianIcon(xmlWeather);
                    item.HouTianLow = GoogleWeatherHelper.GetHouTianLow(xmlWeather);
                    item.HouTianHight = GoogleWeatherHelper.GetHouTianHight(xmlWeather);
                    item.HouTianCondition = GoogleWeatherHelper.GetHouTianCondition(xmlWeather);

                    item.DaHouTianWeek = GoogleWeatherHelper.GetDaHouTianWeek(xmlWeather);
                    item.DaHouTianIcon = GoogleWeatherHelper.GetDaHouTianIcon(xmlWeather);
                    item.DaHouTianLow = GoogleWeatherHelper.GetDaHouTianLow(xmlWeather);
                    item.DaHouTianHight = GoogleWeatherHelper.GetDaHouTianHight(xmlWeather);
                    item.DaHouTianCondition = GoogleWeatherHelper.GetDaHouTianCondition(xmlWeather);
                }
            }
            IsolatedStorageSettings.ApplicationSettings["City"] = citys;
            IsolatedStorageSettings.ApplicationSettings.Save();
            NavigationService.Navigate(new Uri("/" + AndGoPage + ".xaml?cityName=" + cityName, UriKind.RelativeOrAbsolute));
        }
    }
}