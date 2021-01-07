using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    class SuportViewModel : BindableBase
    {
        private LoginViewModel lgVM;
        public LoginViewModel LgVM
        {
            set
            {
                lgVM = value;
            }
            get
            {
                return lgVM;
            }
        }
        private MainViewModel mainVM;
        public MainViewModel MainVM
        {
            set
            {
                mainVM = value;
            }
            get
            {
                return mainVM;
            }
        }


        public SuportViewModel()
        {
            LgVM = new LoginViewModel();
            MainVM = new MainViewModel();

        }

    }
}
