using Restaurant.Commands;
using Restaurant.Data;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Restaurant.ViewModels
{
    class RegisterViewModel
    {
        SqlConnection con;

        private String name;
        public String Name {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        private String surname;
        public String Surname
        {
            set
            {
                surname = value;
            }
            get
            {
                return surname;
            }
        }
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
        private String adress;
        public String Adress
        {
            set
            {
                adress = value;
            }
            get
            {
                return adress;
            }
        }
        private String phone;
        public String Phone
        {
            set
            {
                phone = value;
            }
            get
            {
                return phone;
            }
        }


        public RegisterViewModel()
        {
            var connection = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            con = new SqlConnection(connection);
        }


        private ICommand exit;

        public ICommand Exit => exit = new RelayCommand(o =>
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            ((Window)o).Close();
        });

        private ICommand register;
        public ICommand Register => register = new RelayCommand(c =>
        {
            bool show = true;
            DataTable dt = new DataTable();
            using (SqlConnection conn = con)
            {
                using (SqlCommand cmd = new SqlCommand("CreateUser2", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter nameP = new SqlParameter("@Name", SqlDbType.NVarChar);
                    SqlParameter surnameP = new SqlParameter("@Surname", SqlDbType.NVarChar);
                    SqlParameter emailP = new SqlParameter("@Email", SqlDbType.NVarChar);
                    SqlParameter phoneP = new SqlParameter("@Phone", SqlDbType.NVarChar);
                    SqlParameter passP = new SqlParameter("@Password", SqlDbType.NVarChar);
                    SqlParameter adressP = new SqlParameter("@Adress", SqlDbType.NVarChar);

                    try
                    {
                        nameP.Value = Name;
                        surnameP.Value = Surname;
                        emailP.Value = Email;
                        phoneP.Value = Phone;
                        passP.Value = Password;
                        adressP.Value = Adress;
                    }
                    catch
                    {
                        Console.WriteLine("Error!");
                    }


                    cmd.Parameters.Add(nameP);
                    cmd.Parameters.Add(surnameP);
                    cmd.Parameters.Add(emailP);
                    cmd.Parameters.Add(adressP);
                    cmd.Parameters.Add(phoneP);
                    cmd.Parameters.Add(passP);
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            ad.Fill(dt);
                        }
                        catch
                        {
                            MessageBox.Show("One fild is empty!");
                            show = false;
                        }
                        
                    }

                }
            }
            if (show == true)
            {
                MessageBox.Show("User was created!");
            }


        });
    }
}
