using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Group_Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.ViewModel
{
    public partial class AdminMenuVM:ObservableObject
    {
        public AdminMenuVM()
        {

        }

        [RelayCommand]
        public void OpenAdminViewWindow()
        {
            var view = new adminView();
            view.Show();
        }

        [RelayCommand]
        //to open addmodule window
        public void OpenAddModuleWindow()
        {
            var view = new AddModuleWindow();
            view.Show();
        }
    }
}
