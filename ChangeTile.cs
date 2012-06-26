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
using Microsoft.Phone.Shell;
using System.Linq;
namespace Weather
{
    //修改磁贴
    public static class ChangeTile
    {
        public static void ChangeTileByCityName(string cityName, string tileBack, string info, string cityTemperature)
        {
            ShellTile TileToFind = ShellTile.ActiveTiles.First();
            StandardTileData NewTileData = new StandardTileData();
            NewTileData.Title = cityName;
            NewTileData.BackgroundImage = new Uri("/Images/Tile/"+TimeTools.GetDayorNight()+"/"+tileBack+".png", UriKind.Relative);
            NewTileData.BackTitle = info;
            NewTileData.BackBackgroundImage = new Uri("/Images/Tile/"+TimeTools.GetDayorNight()+"/"+tileBack+".png", UriKind.Relative);
            NewTileData.BackContent = cityTemperature;
            TileToFind.Update(NewTileData);
        }
    }
}
