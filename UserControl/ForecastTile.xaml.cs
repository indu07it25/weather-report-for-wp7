using System;
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
	public partial class ForecastTile : UserControl
	{
		public ForecastTile()
		{
			// 为初始化变量所必需
			InitializeComponent();
		}

        public ImageSource Weathericon { get { return imgWeathericon.Source; } set { imgWeathericon.Source = value; } }

        public string WhichDay { get { return txtWhichDay.Text; } set { txtWhichDay.Text = value; } }

        public string Temperature { get { return txtTemperature.Text; } set { txtTemperature.Text = value; } }
	}
}