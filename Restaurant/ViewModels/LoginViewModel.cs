using Restaurant.Commands;
using Restaurant.Data;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Restaurant.ViewModels
{
    class LoginViewModel
    {
        SqlConnection con;

        private String email;
        public String Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }


        private String password;
        public String Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }

        databaseWPFEntities1 databaseWPFEntities1;
        ObjectResult<Nullable<int>> users;
        public Action CloseAction { get; set; }
        public LoginViewModel()
        {
            var connection = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            con = new SqlConnection(connection);

            databaseWPFEntities1 = new databaseWPFEntities1();
     

        }



        private SPLoginAndReturnUser_Result util;
        private ICommand login;
        public ICommand Login => login = new RelayCommand(o => 
        {
           var user = databaseWPFEntities1.SPLoginAndReturnUser(Email, ((PasswordBox)o).Password);
           var result= user.Select(x => new SPLoginAndReturnUser_Result
           {
                     UserId = x.UserId,
                     Name = x.Name,
                     Surname =x.Surname,
                     Email =x.Email,
                     Adress =x.Adress,
                     Phone =x.Phone,
                     denumire = x.denumire


           }).ToList();
            writeData(Email, ((PasswordBox)o).Password);

            if (result.Count>0)
            {

               
                //MessageBox.Show("LG OK!");
                SPLoginAndReturnUser_Result utilizator = result.ElementAt(0);
                util = utilizator;
                MainView view = new MainView(utilizator);
                //MainViewModel model = new MainViewModel(utilizator);
                //model.userDetails = utilizator;
                //view.DataContext = model;
                view.Show();
                CloseAction();
            }
            else
            {
                MessageBox.Show("Emailul sau parola nu sunt corecte!");
            }

        });

        private ICommand guestLogin;

        public ICommand GuestLogin => guestLogin = new RelayCommand(o => 
        {
            string docPath = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");
            System.IO.File.WriteAllText(System.IO.Path.Combine(docPath, "utils.txt"), string.Empty);

            MainView view = new MainView();
            view.Show();
            CloseAction();
        });

        public void writeData(string e,string pass)
        {
            
            List<String> list = new List<string>();
            list.Add(e);
            list.Add(pass);
            string docPath = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");
            System.IO.File.WriteAllText(System.IO.Path.Combine(docPath, "utils.txt"), string.Empty);
            File.AppendAllLines(System.IO.Path.Combine(docPath, "utils.txt"), list);

        }




        private ICommand exit;

        public ICommand Exit => exit = new RelayCommand(o => ((Window)o).Close());

        private ICommand register;

        public ICommand Register => register = new RelayCommand( o=> {  RegisterView registerView = new RegisterView(); registerView.Show(); ((Window)o).Close(); }  );

    }
}
