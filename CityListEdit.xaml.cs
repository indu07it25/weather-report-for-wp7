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
namespace Weather
{
    public partial class CityListEdit : PhoneApplicationPage
    {
        List<CityWeatherInfo> citys = new List<CityWeatherInfo>();
        public CityListEdit()
        {
            InitializeComponent();

            BindData();
        }

        private void BindData()
        {
            citys = IsolatedStorageSettings.ApplicationSettings["City"] as List<CityWeatherInfo>;
            listBoxCityList.ItemsSource = null;
            listBoxCityList.ItemsSource = citys;
        }

        private void linkButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            AddCityButton.Content = "修改";
            CityNameTextBox.Text = ((HyperlinkButton)sender).TargetName;
            CityNameTextBox.Tag = ((HyperlinkButton)sender).Tag.ToString();
            LayoutRoot.RowDefinitions[0].Height = new GridLength(100);

        }

        private void linkButtonDel_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < citys.Count; i++)
            {
                if (citys[i].CityGuid == ((HyperlinkButton)sender).Tag.ToString())
                {
                    citys.RemoveAt(i);
                }
            }
            IsolatedStorageSettings.ApplicationSettings["City"] = citys;
            IsolatedStorageSettings.ApplicationSettings.Save();
            BindData();
        }

        private void appbarbtnAdd_Click(object sender, EventArgs e)
        {
            AddCityButton.Content = "添加";
            LayoutRoot.RowDefinitions[0].Height = new GridLength(100);
        }

        private void AddCityButton_Click(object sender, RoutedEventArgs e)
        {
            
            if ((citys.Where(list => list.CityName == CityNameTextBox.Text).ToList()).Count == 0)
            {
                citys.Add(new CityWeatherInfo() { CityGuid = Guid.NewGuid().ToString(), CityName = CityNameTextBox.Text });
                IsolatedStorageSettings.ApplicationSettings["City"] = citys;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
            IsolatedStorageSettings.ApplicationSettings["City"] = citys;
            IsolatedStorageSettings.ApplicationSettings.Save();
            NavigationService.Navigate(new Uri("/Loading.xaml?cityName=" + CityNameTextBox.Text+"&AndGoPage=MainPage", UriKind.RelativeOrAbsolute));
        }

        private void CancelCityButton_Click(object sender, RoutedEventArgs e)
        {
            LayoutRoot.RowDefinitions[0].Height = new GridLength(0);
        }
    }
}