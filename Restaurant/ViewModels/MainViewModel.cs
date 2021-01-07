using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Input;
using Restaurant.Commands;
using System.Windows;
using System.Windows.Controls;
using Restaurant.Models;
using Prism.Mvvm;
using Restaurant.Views;

namespace Restaurant.ViewModels
{
    class MainViewModel : BaseVM
    {

        

        public class Parat:BaseVM
        {
            public SPGetPreparate_Result preparats;
            public string alergens;
            public string disponibilitate;
            public List<string> poze;
            public string poza1 { set; get; }
            public string poza2 { set; get; }
            public string poza3 { set; get; }

            public string Poza1
            { set
                {
                    poza1 = value;
                }
              get
                {
                    return poza1;
                }
            }
            public string Poza2 { set; get; }
            public string Poza3 { set; get; }


            public int cantitate = 0;
            

            public SPGetPreparate_Result Name
            {
                get { return preparats; }
                set { preparats = value; }
            }

            public string Address
            {
                get { return alergens; }
                set { alergens = value; }
            }
            public string Disponibilitate
            {
                set { disponibilitate = value; }
                get { return disponibilitate; }
            }
            public List<string> Poze
            {
                set { poze = value;
                    if (poze.Count == 3)
                    {
                        poza1 = poze.ElementAt(0);
                        poza2 = poze.ElementAt(1);
                        poza3 = poze.ElementAt(2);
                        OnPropertyChanged("poza1");
                        OnPropertyChanged("poza2");
                        OnPropertyChanged("poza3");
                    }
                    if (poze.Count == 2)
                    {
                        poza1 = poze.ElementAt(0);
                        poza2 = poze.ElementAt(1);
                        OnPropertyChanged("poza1");
                        OnPropertyChanged("poza2");

                    }
                    if (poze.Count == 1)
                    {
                        poza1 = poze.ElementAt(0);   
                        OnPropertyChanged("poza1");
                    }
                    OnPropertyChanged("poze");
                }
                get { return poze; }
            }

            public int Cantitate
            {
                set { cantitate = value;
                    
                }
                get { return cantitate; }
            }
            public void incremet()
            {
                cantitate = cantitate + 1;
                OnPropertyChanged("cantitate");
            }
            public void decrement()
            {
                if (cantitate != 0)
                {
                    cantitate = cantitate - 1;
                    OnPropertyChanged("cantitate");
                }
                else
                {
                    MessageBox.Show("Cantitatea nu poate sa fie mai mica de 0 !");
                }
            }
            public string ToString()
            {
                { return preparats + alergens+disponibilitate+poze.ToString()+cantitate.ToString(); }
            }
        }
        public class MeniulPret:BaseVM
        {
            SPGetMeniuriByCategorie_Result meniu;
            double val;
            public string disponibilitate;

            public int cantitate = 0;
            public int Cantitate
            {
                set
                {
                    cantitate = value;

                }
                get { return cantitate; }
            }
            public void incremet()
            {
                cantitate = cantitate + 1;
                OnPropertyChanged("cantitate");
            }
            public void decrement()
            {
                if (cantitate != 0)
                {
                    cantitate = cantitate - 1;
                    OnPropertyChanged("cantitate");
                }
                else
                {
                    MessageBox.Show("Cantitatea nu poate sa fie mai mica de 0 !");
                }
            }

            public SPGetMeniuriByCategorie_Result Meniu
            {
                get { return meniu; }
                set { meniu = value; }
            }

            public double Val
            {
                get { return val; }
                set { val = value; }
            }
            public string Disponibilitate
            {
                set
                {
                    disponibilitate = value;
                    OnPropertyChanged("disponibilitate");
                }
                get
                {
                    return disponibilitate;
                }
            }

            public string ToString()
            {
                { return val + meniu.denumire+disponibilitate; }
            }
        }

        SqlConnection con;

        databaseWPFEntities1 contex;

        public List<SPGetPreparate_Result> preparate { get; set; }

        public List<string> Alergeni { get; set; }

        public List<Parat> preparatComplet;
        public List<Parat> PreparatComplet {
            set
            {
                
                preparatComplet = value;
                OnPropertyChanged("preparatComplet");
            }
            get
            {
                return preparatComplet;
            }
        }

        private List<SPGetMeniuriByCategorie_Result> meniues;
       public List<SPGetMeniuriByCategorie_Result> Meniues
        {
            set
            {
                meniues = value;
                OnPropertyChanged("meniues");
            }
            get
            {
                return meniues;
            }
        }
        private string hide;
        private string hideAdmin;
        public string Hide {
            set
            {
                hide = value;
                OnPropertyChanged("hide");
            }
            get
            {
                return hide;
            }

        }
        public string HideAdmin
        {
            set
            {
                hideAdmin = value;
                OnPropertyChanged("hideAdmin");
            }
            get
            {
                return hideAdmin;
            }

        }
        public int discount { set; get; }

        private List<double> prices;
        public List<double> Prices
        {
            set
            {
                prices = value;
                OnPropertyChanged("Prices");
            }
            get
            {
                return prices;
            }
        }

        private List<MeniulPret> mp;
       public List<MeniulPret> Mp
        {
            set
            {
                mp = value;
                OnPropertyChanged("mp");
            }
            get
            {
                return mp;
            }
        }
       public User utilizator { set; get; }
        public SPLoginAndReturnUser_Result userDetails { set; get; }

        private string textSearch;
        public string TextSearch
        {
            set
            {
                textSearch = value;
            }
            get
            {
                return textSearch;
            }
        }

        bool searchByAlergeni;
        public bool SearchByAlergeni
        {
            set
            {
                searchByAlergeni = value;
                OnPropertyChanged("searchByAlergeni");
            }
            get
            {
                return searchByAlergeni;
            }
        }
        public string Img { set; get; }

        public bool buttonEnable;
        public bool ButtonEnable
        {
            set { buttonEnable = value;
                OnPropertyChanged("buttonEnable");
                OnPropertyChanged("ButtonEnable");
            }
            get
            {
                return buttonEnable;
            }
        }

   
         
        public MainViewModel()
        {
            HideAdmin = "Hidden";
            ButtonEnable = false;
            initializer();
  
        }
        public MainViewModel(SPLoginAndReturnUser_Result user )
        {
             
            initializer();
 
        }


        public void smth()
        {
            System.IO.StreamReader file =
               new System.IO.StreamReader("../../utils.txt");
            String email="";
            String pass="";
            string line;

            while ((line = file.ReadLine()) != null)
            {
                email = line;
                line = file.ReadLine();
                System.Console.WriteLine(line);
                pass = line;
            }
            file.Close();
            System.Console.ReadLine();
            if(email!="" && pass!="")
            {

                var user = contex.SPLoginAndReturnUser(email, pass);
                var result = user.Select(x => new SPLoginAndReturnUser_Result
                {
                    UserId = x.UserId,
                    Name = x.Name,
                    Surname = x.Surname,
                    Email = x.Email,
                    Adress = x.Adress,
                    Phone = x.Phone,
                    denumire = x.denumire


                }).ToList();


                userDetails  = result.ElementAt(0);



                Hide = null;
                HideAdmin = null;

                if (userDetails.denumire.Trim() == "Utilizator")
                {
                    Hide = "Visible";
                    HideAdmin = "Hidden";
                }
                else if (userDetails.denumire.Trim() == "Lucrator")
                {
                    Hide = "Hidden";
                    HideAdmin = "Visible";
                }
                buttonEnable = new bool();
                ButtonEnable = true;
                buttonEnable = true;
                OnPropertyChanged("buttonEnable");

                OnPropertyChanged("ButtonEnable");


            }


        }

        public void initializer()
        {
            
            //hide = "";
            //hideAdmin = "";
            textSearch = "";
            //buttonEnable = true;
            utilizator = new User();
            Meniues = new List<SPGetMeniuriByCategorie_Result>();
            Alergeni = new List<string>();
            var connection = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            discount = int.Parse(ConfigurationManager.AppSettings["reducere"]);
            con = new SqlConnection(connection);
            contex = new databaseWPFEntities1();
            preparate = LoadPreparate();
            
            PreparatComplet = CreatePreparatComplex(Alergeni, preparate);
            Meniues = GetAllMenius();
            Prices = GetAllMenuPrices();
            Mp = CreateMeniuComplex(Prices, Meniues);
            smth();
            Img = "https://www.gannett-cdn.com/-mm-/c8dac0cd22f6b4730ca34d62cb389b1cca7e953b/c=0-14-2284-1299/local/-/media/2020/02/28/USATODAY/usatsports/gettyimages-1154896831.jpg";
        }

        private ICommand search;
        public ICommand Search => search = new RelayCommand(o =>
         {
         if (o == null)
         {
             MessageBox.Show("Selecteaza o categorie unde vrei sa cauti!");


         }
             try
             {

                 string name = ((ListBoxItem)o).Content.ToString();
                 if (SearchByAlergeni == false)
                 {
                     if (name == "all")
                     {
                         var res = contex.SPSearchPreparatAll(TextSearch);
                         var result2 = res.Select(x => new SPSearchPreparatAll_Result
                         {
                             id_preparat = x.id_preparat,
                             id_categorie = x.id_categorie,
                             cantintate_portie = x.cantintate_portie,
                             cantitate_restaurant = x.cantitate_restaurant,
                             denumire = x.denumire
                            ,
                             pret = x.pret
                         }).ToList();

                         List<SPGetPreparate_Result> l = new List<SPGetPreparate_Result>();


                         for (int i = 0; i < result2.Count; i++)
                         {
                             SPGetPreparate_Result p = new SPGetPreparate_Result();
                             p.cantintate_portie = result2.ElementAt(i).cantintate_portie;
                             p.cantitate_restaurant = result2.ElementAt(i).cantitate_restaurant;
                             p.denumire = result2.ElementAt(i).denumire;
                             p.id_categorie = result2.ElementAt(i).id_categorie;
                             p.id_preparat = result2.ElementAt(i).id_preparat;
                             p.pret = result2.ElementAt(i).pret;
                             l.Add(p);
                         }

                         //meniu
                         Meniues.Clear();


                         var resM = contex.SPSearchMenuAll(TextSearch);
                         var result2M = resM.Select(x => new SPSearchMenuAll_Result
                         {
                             denumire = x.denumire,
                             id_categorie = x.id_categorie,
                             id_meniu = x.id_meniu

                         }).ToList();


                         List<SPGetMeniuriByCategorie_Result> mens = new List<SPGetMeniuriByCategorie_Result>();


                         for (int i = 0; i < result2M.Count; i++)
                         {
                             SPGetMeniuriByCategorie_Result m = new SPGetMeniuriByCategorie_Result();
                             m.denumire = result2M.ElementAt(i).denumire;
                             m.id_categorie = result2M.ElementAt(i).id_categorie;
                             m.id_meniu = result2M.ElementAt(i).id_meniu;
                             mens.Add(m);
                         }

                         Meniues = new List<SPGetMeniuriByCategorie_Result>();
                         Alergeni = new List<string>();
                         GetAllergeni(l);
                         PreparatComplet = CreatePreparatComplex(Alergeni, l);
                         Meniues = mens;
                         Prices = GetAllMenuPrices();
                         Mp = CreateMeniuComplex(Prices, Meniues);
                     }
                     else
                     {
                         // creare preparate
                         var res = contex.SPSearchPreparatByCategorie(TextSearch, name);
                         var result2 = res.Select(x => new SPSearchPreparatByCategorie_Result
                         {
                             id_preparat = x.id_preparat,
                             id_categorie = x.id_categorie,
                             cantintate_portie = x.cantintate_portie,
                             cantitate_restaurant = x.cantitate_restaurant,
                             denumire = x.denumire
                            ,
                             pret = x.pret
                         }).ToList();

                         List<SPGetPreparate_Result> l = new List<SPGetPreparate_Result>();


                         for (int i = 0; i < result2.Count; i++)
                         {
                             SPGetPreparate_Result p = new SPGetPreparate_Result();
                             p.cantintate_portie = result2.ElementAt(i).cantintate_portie;
                             p.cantitate_restaurant = result2.ElementAt(i).cantitate_restaurant;
                             p.denumire = result2.ElementAt(i).denumire;
                             p.id_categorie = result2.ElementAt(i).id_categorie;
                             p.id_preparat = result2.ElementAt(i).id_preparat;
                             p.pret = result2.ElementAt(i).pret;
                             l.Add(p);
                         }

                         // creare meniuri
                         Meniues.Clear();


                         var resM = contex.SPSearchMenuByCategorie2(TextSearch, name);
                         var result2M = resM.Select(x => new SPSearchMenuByCategorie_Result
                         {
                             denumire = x.denumire,
                             id_meniu = x.id_meniu,
                             id_categorie = x.id_categorie
                         }).ToList();


                         List<SPGetMeniuriByCategorie_Result> mens = new List<SPGetMeniuriByCategorie_Result>();


                         for (int i = 0; i < result2M.Count; i++)
                         {
                             SPGetMeniuriByCategorie_Result m = new SPGetMeniuriByCategorie_Result();
                             m.denumire = result2M.ElementAt(i).denumire;
                             m.id_categorie = result2M.ElementAt(i).id_categorie;
                             m.id_meniu = result2M.ElementAt(i).id_meniu;
                             mens.Add(m);
                         }



                         Meniues = new List<SPGetMeniuriByCategorie_Result>();
                         Alergeni = new List<string>();
                         GetAllergeni(l);
                         PreparatComplet = CreatePreparatComplex(Alergeni, l);
                         Meniues = mens;
                         Prices = GetAllMenuPrices();
                         Mp = CreateMeniuComplex(Prices, Meniues);

                     }
                 }
                 else
                 {

                     Meniues = new List<SPGetMeniuriByCategorie_Result>();
                     Alergeni = new List<string>();

                     PreparatComplet = searchAlergeni(TextSearch);
                     //Meniues = mens;
                     Prices = GetAllMenuPrices();
                     Mp = CreateMeniuComplex(Prices, Meniues);

                 }
                 RefreshViewFromCart();
             }
            
             catch
             {

             }

         });


        private ICommand comanda;
        public ICommand Comanda => comanda = new RelayCommand(o =>
       {
           if (carts.Count > 0)
           {
               Nullable<double> pretTotal = 0;

               contex.InregistrareComanda(userDetails.UserId);
               for (int i = 0; i < carts.Count; i++)
               {
                   var val = carts.ElementAt(i);
                   if (val.Type == "P")
                   {
                       contex.SPInsertPreparatInComanda2(userDetails.UserId, val.Nume, val.Cantitate, val.Pret * val.Cantitate);
                       pretTotal = val.Pret * val.Cantitate;
                   }
                   else if (val.Type == "M")
                   {
                       contex.SPInsertMenuInComanda2(userDetails.UserId, val.Nume, val.Cantitate, val.Pret * val.Cantitate);
                       pretTotal = val.Pret * val.Cantitate;
                   }
               }

               contex.PretComanda(userDetails.UserId, pretTotal);


               MessageBox.Show("Comanda a fost plasata!");
           }
           else
           {
               MessageBox.Show("Cosul este gol!");
           }
       });

        private ICommand comenziStatus;
        public ICommand ComenziStatus => comenziStatus = new RelayCommand(o => { ComenziView comenziView = new ComenziView(); comenziView.Show(); });

        public List<Parat> searchAlergeni(string val)
        {
            List<Parat> pcs = new List<Parat>();
            
            for (int i =0;i< PreparatComplet.Count; i++)
            {
                if(PreparatComplet.ElementAt(i).alergens.Contains(val))
                {
                    Parat pc = new Parat();
                    pc.Address = PreparatComplet.ElementAt(i).Address;
                    pc.Cantitate = PreparatComplet.ElementAt(i).Cantitate;
                    pc.Disponibilitate = PreparatComplet.ElementAt(i).Disponibilitate;
                    pc.Name = PreparatComplet.ElementAt(i).Name;
                    pc.Poza1 = PreparatComplet.ElementAt(i).Poza1;
                    pc.Poza2 = PreparatComplet.ElementAt(i).Poza2;
                    pc.Poza3 = PreparatComplet.ElementAt(i).Poza3;
                    pc.Poze = PreparatComplet.ElementAt(i).Poze;
                    pcs.Add(pc);
                }
            }

            return pcs;

        }


        private ICommand addEdditMenu;
        public ICommand AddEdditMenu => addEdditMenu = new RelayCommand(o =>
         {
             if (o == null)
             {
                 AddEdditMeniu addEdditMeniu = new AddEdditMeniu();
                 addEdditMeniu.Show();
             }
             else
             {
                 AddEdditMeniu addEddit = new AddEdditMeniu();
                 AddEdditMeniuViewModel addEdditPreparatViewModel = new AddEdditMeniuViewModel((MeniulPret)o);
                 addEddit.DataContext = addEdditPreparatViewModel;
                 addEddit.Show();
             }

         });


        private ICommand addEdditPreparat;
        public ICommand AddEdditPreparat => addEdditPreparat = new RelayCommand(o =>
        {
            if(o==null)
            {
                AddEdditPreparate addEddit = new AddEdditPreparate();
                addEddit.Show();
            }
            else
            {
                AddEdditPreparate addEddit = new AddEdditPreparate();
                AddEdditPreparatViewModel addEdditPreparatViewModel = new AddEdditPreparatViewModel((Parat)o);
                addEddit.DataContext = addEdditPreparatViewModel;
                addEddit.Show();
            }
            

        });

        private ICommand removePreparat;
        public ICommand RemovePreparat => removePreparat = new RelayCommand(o => {
            contex = new databaseWPFEntities1();
            if (o!=null)
            {
                var name = ((Parat)o).Name.denumire;
                contex.DeletePozePreparat(name);
                contex.DeleteAlergeniPreparat(name);
                contex.DeletePreparat(name);
                MessageBox.Show("Preparatul, " + name + " a fost sters!");
            }
            else
            {
                MessageBox.Show("Selecteaza un Preparat!");
            }
            Meniues.Clear();
            Alergeni.Clear();
            var output = contex.SPGetAllMenues();
            preparate = LoadPreparate();
            PreparatComplet = CreatePreparatComplex(Alergeni, preparate);
            Meniues = GetAllMenius();
            Prices = GetAllMenuPrices();
            Mp = CreateMeniuComplex(Prices, Meniues);

        });

        private ICommand removeMenu;
        public ICommand RemoveMenu => removeMenu = new RelayCommand(o => 
        {
            contex = new databaseWPFEntities1();

            if (o != null)
            {
                contex.DeleteMeniuPreparate(o.ToString());
                contex.DeleteMeniu(o.ToString());
                MessageBox.Show("Meniul, " + o.ToString() + " a fost sters!");
            }
            else
            {
                MessageBox.Show("Selecteaza un Meniu!");
            }

            Meniues.Clear();
            Alergeni.Clear();
            var output = contex.SPGetAllMenues();
            preparate = LoadPreparate();
            PreparatComplet = CreatePreparatComplex(Alergeni, preparate);
            Meniues = GetAllMenius();
            Prices = GetAllMenuPrices();
            Mp = CreateMeniuComplex(Prices, Meniues);
        });


        private List<Cart> carts = new List<Cart>();

        public void  AddToCart(object o)
        {
            Cart c = new Cart();
            if (carts.Count == 0)
            {
                if (o.GetType().Equals(typeof(Parat)))
                {
                    var aux = ((Parat)o);
                    c = new Cart();
 
                    c.Cantitate = aux.Cantitate;
                    c.Nume = aux.Name.denumire.Trim();
                    c.Pret = aux.Name.pret;
                    c.Type = "P";
                       
                    carts.Add(c);
                }

                if (o.GetType().Equals(typeof(MeniulPret)))
                {
                    var aux = ((MeniulPret)o);

                        c = new Cart();
                        c.Cantitate = aux.Cantitate;
                        c.Nume = aux.Meniu.denumire.Trim();
                        c.Pret = Prices.ElementAt(Meniues.IndexOf(aux.Meniu));
                    c.Type = "M";
                    carts.Add(c);
                }
            }
            else
            {
                for (int i = 0; i < carts.Count; i++)
                {

                    if (o.GetType().Equals(typeof(Parat)))
                    {
                        var aux = ((Parat)o);
                        string s = aux.Name.denumire;
                        if (carts.ElementAt(i).Nume.Trim()==(s.Trim()))
                        {
                            carts.ElementAt(i).Cantitate = aux.Cantitate;
                        }
                        else if(i == carts.Count - 1)
                        {
                            c = new Cart();
                            c.Cantitate = aux.Cantitate;
                            c.Nume = aux.Name.denumire.Trim();
                            c.Pret = aux.Name.pret;
                            c.Type = "P";
                            carts.Add(c);
                        }

                    }

                    if (o.GetType().Equals(typeof(MeniulPret)))
                    {
                        var aux = ((MeniulPret)o);
                        if (carts.ElementAt(i).Nume.Trim()==(aux.Meniu.denumire.Trim()))
                        {
                            carts.ElementAt(i).Cantitate = aux.Cantitate;
                        }
                        else if(i==carts.Count-1)
                        {
                            c = new Cart();
                            c.Cantitate = aux.Cantitate;
                            c.Nume = aux.Meniu.denumire.Trim();
                            c.Pret = Prices.ElementAt(Meniues.IndexOf(aux.Meniu));
                            c.Type = "M";
                            carts.Add(c);
                        }

                    }


                }


            }

        }

        public void RefreshViewFromCart()
        {
            for(int i =0;i< PreparatComplet.Count;i++)
            {
                for(int j =0;j<carts.Count;j++)
                {
                    if (preparatComplet.ElementAt(i).Name.denumire.Trim()==carts.ElementAt(j).Nume.Trim())
                    {
                        PreparatComplet.ElementAt(i).Cantitate = carts.ElementAt(j).Cantitate;
                    }

                }
               
            }
            for (int i = 0; i < Mp.Count; i++)
            {
                for (int j = 0; j < carts.Count; j++)
                {
                    if (Mp.ElementAt(i).Meniu.denumire.Trim() == carts.ElementAt(j).Nume.Trim())
                    {
                        Mp.ElementAt(i).Cantitate = carts.ElementAt(j).Cantitate;
                    }

                }

            }
        }

        private ICommand incrementQ;
        public ICommand IncrementQ => incrementQ = new RelayCommand(o => {
            if (o == null)
            {
                MessageBox.Show("Selecteaza un meniu!");
                }
            else
            {
                ((Parat)o).incremet();
                AddToCart(o);
            }
            
         });

        private ICommand decrementQ;
        public ICommand DecrementQ => decrementQ = new RelayCommand(o => {
            if (o == null)
            {
                MessageBox.Show("Selecteaza un meniu!");
                        }
            else
            {
                ((Parat)o).decrement();
                AddToCart(o);
            }
        });

        private ICommand incrementMenuQ;
        public ICommand IncrementMenuQ => incrementMenuQ = new RelayCommand(o => {
            if(o==null)
            {
                MessageBox.Show("Selecteaza un meniu!");
            }
            else
            {
                ((MeniulPret)o).incremet();
                AddToCart(o);
            }
            

        });

        private ICommand decrementMenuQ;
        public ICommand DecrementMenuQ => decrementMenuQ = new RelayCommand(o => {
            if (o == null)
            {
                MessageBox.Show("Selecteaza un meniu!");
            }
            else
            {
                ((MeniulPret)o).decrement();
                AddToCart(o);
            }
        });


        public List<string> checkDisponibilityOnPreparat(List<SPGetPreparate_Result> val)
        {
            List<string> disponibil = new List<string>();
            for (int i =0;i<val.Count;i++)
            {


                if (val.ElementAt(i).cantitate_restaurant == 0)
                {

                        disponibil.Add("Indisponibil");
                }
                else if( val.ElementAt(i).cantitate_restaurant < val.ElementAt(i).cantintate_portie)
                {
                    if (val.ElementAt(i).id_categorie == 1)
                    {
                        disponibil.Add("Disponibil");
                    }
                    else
                    {
                        disponibil.Add("Indisponibil");
                    }
                }
                else
                {
                    disponibil.Add("Disponibil");
                }

            }
            return disponibil;
        }
        public List<string> getPozeForPreparat(string prep)
        {
            var opt = contex.SPGetAllPhotosForPreparat(prep);


            var result2 = opt.Select(x => new SPGetAllPhotosForPreparat_Result
            {
                id_poza = x.id_poza,
                link = x.link
            }).ToList();

            var result = new List<string>();
            for(int i = 0;i<result2.Count;i++)
            {
                result.Add(result2.ElementAt(i).link);
            }

            if (result.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    result.Add("");
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        private ICommand changeCategorie;
        public ICommand ChangeCategorie => changeCategorie = new RelayCommand(o =>
        {
            if (o==null)
            {
                MessageBox.Show("Selecteaza o categorie!");


            }
            try
            {
                string name = ((ListBoxItem)o).Content.ToString();
                if (name != "all")
                {
                    var output = contex.SPGetPreparateByCategorie(name);

                    var result = output.Select(x => new SPGetPreparateByCategorie_Result
                    {
                        cantintate_portie = x.cantintate_portie,
                        cantitate_restaurant = x.cantitate_restaurant,
                        denumire = x.denumire,
                        id_categorie = x.id_categorie,
                        id_preparat = x.id_preparat,
                        pret = x.pret
                    }).ToList();
                    Meniues.Clear();
                    Meniues= GetMeniuFromCategorie(name);

                    var result2 = new List<SPGetPreparate_Result>();

                    for (int i = 0; i < result.Count; i++)
                    {
                        result2.Add(PreparateConverter(result.ElementAt(i)));
                    }


                    preparate = result2;
                    //GetAlergeniPreparat(result.ElementAt(3).denumire);
                    Alergeni.Clear();
                    GetAllergeni(result2);
                    PreparatComplet = CreatePreparatComplex(Alergeni, preparate);
                    Prices = GetAllMenuPrices();
                    Mp = CreateMeniuComplex(Prices, Meniues);
                }
                else
                {
                    Meniues.Clear();
                    Alergeni.Clear();
                    var output = contex.SPGetAllMenues();
                    preparate = LoadPreparate();
                    PreparatComplet = CreatePreparatComplex(Alergeni, preparate);
                    Meniues = GetAllMenius();
                    Prices = GetAllMenuPrices();
                    Mp = CreateMeniuComplex(Prices, Meniues);
                }
                RefreshViewFromCart();
            }
            catch
            {

            }
        }
        );

        private ICommand exit;

        public ICommand Exit => exit = new RelayCommand(o => {

            LoginView loginView = new LoginView();
            loginView.Show();

            ((Window)o).Close();
        }
        );

        private ICommand viewComanda;

        public ICommand ViewComanda => viewComanda = new RelayCommand(o => {
            ComenziPropriView comenziPropriView = new ComenziPropriView();
            ComenziPropriViewModel comenziPropriViewModel = new ComenziPropriViewModel(userDetails.Email);
            comenziPropriView.DataContext = comenziPropriViewModel;
            comenziPropriView.Show();
        });

        private ICommand register;

        public ICommand Register => register = new RelayCommand(o => { RegisterView registerView = new RegisterView(); registerView.Show(); ((Window)o).Close(); });
        public double GetMenuPrices(string menu)
        {
            var res=contex.SPGetPreparatePriceSumByMenu(menu);

            var result = res.Select(x => new { Name = x })
            .ToList();


            var menuPrice = result.ElementAt(0).Name.GetValueOrDefault();
            var pretRedus= menuPrice - ((menuPrice * discount)/100);
            return pretRedus;
        }

        public List<double> GetAllMenuPrices()
        {
            List<double> list = new List<double>();
            for (int i =0;i< Meniues.Count();i++)
            {
                var pret = GetMenuPrices(Meniues.ElementAt(i).denumire);
                list.Add(pret);
            }
            return list;
        }

        public List<SPGetMeniuriByCategorie_Result> GetAllMenius()
        {
            var outp = contex.SPGetAllMenues();



           

            var result = outp.Select(x => new SPGetAllMenues_Result
            {
                denumire = x.denumire,
                id_categorie = x.id_categorie,
                id_meniu = x.id_meniu
            }).ToList();

            var result2 = new List<SPGetMeniuriByCategorie_Result>();


            for (int i = 0; i < result.Count; i++)
            {
                result2.Add(MenuConverter(result.ElementAt(i)));
            }

            return result2;
        }

        public SPGetMeniuriByCategorie_Result MenuConverter(SPGetAllMenues_Result val)
        {
            SPGetMeniuriByCategorie_Result aux = new SPGetMeniuriByCategorie_Result();
            aux.denumire = val.denumire;
            aux.id_categorie = val.id_categorie;
            aux.id_meniu = val.id_meniu;
            return aux;
        }

        public string MenueAvalaible(string denumireMeniu)
        {
            var result = GetPreparateForMeniu(denumireMeniu);
            string arg = "Disponibil";
            for(int i =0;i< PreparatComplet.Count;i++)
            {
                var prod = PreparatComplet.ElementAt(i);
                for(int j= 0;j<result.Count;j++)
                {
                    if (prod.Name.denumire.Trim() == result.ElementAt(j).denumire)
                    {
                        if(prod.Disponibilitate== "Indisponibil")
                        {
                            arg = "Indisponibil";
                        }
                    }
                }
                
                
            }
            return arg;
        }


        public List<SPGetMeniuriByCategorie_Result> GetMeniuFromCategorie(string val)
        {
            var outp= contex.SPGetMeniuriByCategorie(val);
            var result = outp.Select(x => new SPGetMeniuriByCategorie_Result
            {
               denumire =x.denumire,
               id_categorie=x.id_categorie,
               id_meniu=x.id_meniu
            }).ToList();

            return result;
        }

        public List<SPGetPreparateByMenu_Result> GetPreparateForMeniu(string meniu)
        {
            var outp = contex.SPGetPreparateByMenu(meniu);
            var result = outp.Select(x => new SPGetPreparateByMenu_Result
            {
              cantitate=x.cantitate,
              cantitate_restaurant=x.cantitate_restaurant,
              denumire=x.denumire,
              pret=x.pret
            }).ToList();

            return result;

        }

        private ICommand menuDetails;
        public ICommand MenuDetails => menuDetails = new RelayCommand(o =>
         {
             if(o==null)
             {
                 MessageBox.Show("Nu ai selectat niciun meniu!");
                 return;
             }
             var denumireMeniu = ((MeniulPret)o).Meniu.denumire;
            var result = GetPreparateForMeniu(denumireMeniu);
             string output = "Meniul "+ denumireMeniu.Trim()+ " contine urmatoarele preparate:\n\n";
             for(int i=0;i<result.Count;i++)
             {
                 output = output +"» " +result.ElementAt(i).denumire +result.ElementAt(i).cantitate+"g/ml"+"\n";
             }

             MessageBox.Show(output);
         });
        public SPGetPreparate_Result PreparateConverter(SPGetPreparateByCategorie_Result val)
        {

            SPGetPreparate_Result val2 = new SPGetPreparate_Result();
            val2.id_preparat = val.id_preparat;
            val2.id_categorie = val.id_categorie;
            val2.pret = val.pret;
            val2.denumire = val.denumire;
            val2.cantintate_portie = val.cantintate_portie;
            val2.cantitate_restaurant = val.cantitate_restaurant;
            return val2;

        }
        public List<MeniulPret> CreateMeniuComplex(List<double> list, List<SPGetMeniuriByCategorie_Result> meniues)
        {
            List<MeniulPret> l = new List<MeniulPret>();
            MeniulPret mp = new MeniulPret();

            for (int i = 0; i < list.Count; i++)
            {
                mp = new MeniulPret();
                mp.Meniu = meniues.ElementAt(i);
                mp.Val = list.ElementAt(i);
                mp.Disponibilitate = MenueAvalaible(meniues.ElementAt(i).denumire);
                l.Add(mp);
            }
            return l;
        }
        public List<Parat> CreatePreparatComplex(List<string> Alergeni, List<SPGetPreparate_Result> preparate)
        {
            List<Parat> p = new List<Parat>();
            List<string> disp = checkDisponibilityOnPreparat(preparate);
            Parat parat = new Parat();
            for (int i =0;i<Alergeni.Count;i++)
            {
                parat = new Parat();
                parat.alergens = Alergeni.ElementAt(i);
                parat.preparats = preparate.ElementAt(i);
                parat.disponibilitate = disp.ElementAt(i);
                parat.Poze = getPozeForPreparat(preparate.ElementAt(i).denumire);
                p.Add(parat);
            }
            return p;
        }
        public List<SPGetPreparate_Result> LoadPreparate()
        {

            var user = contex.SPGetPreparate();
            var result = user.Select(x => new SPGetPreparate_Result
            {
                cantintate_portie = x.cantintate_portie,
                cantitate_restaurant = x.cantitate_restaurant,
                denumire = x.denumire,
                id_categorie = x.id_categorie,
                id_preparat = x.id_preparat,
                pret=x.pret
            }).ToList();


            //GetAlergeniPreparat(result.ElementAt(3).denumire);
            GetAllergeni(result);
            return result;

        }
        public void GetAllergeni(List<SPGetPreparate_Result> result )
        {

            for(int i=0;i<result.Count;i++)
            {
                var alergeniP = GetAlergeniPreparat(result.ElementAt(i).denumire);
                if (alergeniP.Count!=0)
                {
                    Alergeni.Add(listToString(alergeniP).Trim());
                }
                else
                {
                    Alergeni.Add(" ");
                }

            }
        }
        public List<string> GetAlergeniPreparat(string preparat)
        {
            var alergeni = contex.SPGetAllergeniForPreparat(preparat);
            //var result = alergeni.Select(x => new List<string> {  = x }).ToList();


            var result = alergeni.Select(x => new { Name = x})
            .AsEnumerable() //Force EF to materialize the result here
            .Select(x => new List<string> {  x.Name }) //Manipulate the result in memory
            .ToList();
            return ListListToListString(result);
        }
        public List<string> ListListToListString(List<List<String>> ls)
        {
            List<string> list = new List<string>();
            for (int i =0;i<ls.Count;i++)
            {
                string doc = string.Join(",", ls.ElementAt(i).ToArray());
                list.Add(doc.Trim());
            }
            return list;
        }
        public String listToString(List<string> list)
        {
            string doc = string.Join(",", list.ToArray());
            return doc;
        }
    }
}
