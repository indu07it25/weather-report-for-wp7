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
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
namespace Weather
{
    public partial class MainPage : PhoneApplicationPage
    {
        //创建数组存放天气信息
        List<CityWeatherInfo> citys = new List<CityWeatherInfo>();
        
        public MainPage()
        {
            InitializeComponent();
            citys = IsolatedStorageSettings.ApplicationSettings["City"] as List<CityWeatherInfo>;
            BingUI();
        }


        private void BingUI()
        {
            string DayOrNight;
            int hour = DateTime.Now.Hour;
            ImageBrush img = new ImageBrush();
            DayOrNight = TimeTools.GetDayorNight();
            img.ImageSource = new BitmapImage(new Uri("/Images/Back/" + DayOrNight + ".jpg", UriKind.RelativeOrAbsolute));

            LayoutRoot.Background = img;
            foreach (var item in citys)
            {
                AddCity(item.CityName, item.TodayLow + "℃～" + item.TodayHight + "℃", "/Images/Forecasts/" + DayOrNight + "/" + item.TodayIcon + ".png");
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/CityListEdit.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AddCity(string cityName, string cityTemperature, string WeatherIconPath) 
        {
            CityTileData cityData = new CityTileData();
            cityData.cityTemperature = cityTemperature;
            cityData.cityWeatherIcon = WeatherIconPath;
            CityTile city = new CityTile();
            city.DataContext = cityData;
            city.cityName.Content = cityName;
            city.Width = 184;
            city.Height = 105;
            city.Margin = new Thickness(15, 10, 15, 10);
            wrapPanelCityList.Children.Add(city);
            city.cityName.Click += new RoutedEventHandler(cityName_Click);
        }

        void cityName_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Loading.xaml?cityName=" + ((Button)sender).Content + "&AndGoPage=WeatherView", UriKind.RelativeOrAbsolute));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            if (MessageBox.Show("", "确定要退出程序吗", MessageBoxButton.OKCancel)==MessageBoxResult.OK) 
            {
                App.Quit();
            }
            base.OnBackKeyPress(e);
        }
    }
}