using BusanRestaurantApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BusanRestaurantApp.ViewModels
{
    public partial class GoogleMapViewModel : ObservableObject
    {
        public GoogleMapViewModel()
        {
            MatjibLocation = "";

        }

        private BusanItem _selectedMatjibItem;
        public BusanItem SelectedMatjibItem { 
            get => _selectedMatjibItem;
            set {
                SetProperty(ref _selectedMatjibItem, value);
                // 위도(Latitude/Lat), 경도(Longitued/Lng)
                MatjibLocation = $"https://google.com/maps/place/{SelectedMatjibItem.Lat},{SelectedMatjibItem.Lng}";
            }

        }

        private string _matjibLocation;
        public string MatjibLocation
        {
            get => _matjibLocation;
            set => SetProperty(ref _matjibLocation, value);
        }

        
    }
}
