using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BusanRestaurantApp.ViewModels
{
    public partial class GoogleMapViewModel
    {
        IDialogCoordinator dialogCoordinator;

        public GoogleMapViewModel(IDialogCoordinator coordinator)
        {
            this.dialogCoordinator = coordinator;

        }
    }
}
