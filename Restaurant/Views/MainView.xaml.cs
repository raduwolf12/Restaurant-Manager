using Prism.Mvvm;
using Restaurant.Data;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Restaurant.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {

        public MainView()
        {
            InitializeComponent();
            
        }
        public MainView(SPLoginAndReturnUser_Result utilizator)
        {
            InitializeComponent();
            MainViewModel model = new MainViewModel(utilizator);
            model.userDetails = utilizator;
            this.DataContext = model;
            if (model.userDetails == null)
                model.userDetails = utilizator;
        }

    }
}
