using Restaurant.Commands;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Restaurant.ViewModels
{
    class AddEdditMeniuViewModel : BaseVM
    {

       public class CurentMenu:BaseVM
        {
            string denumire;
            int cantitate=0;
            public string Denumire
            {
                set
                {
                    denumire = value;
                    OnPropertyChanged("denumire");
                }
                get
                {
                    return denumire;
                }
            }
            public int Cantitate
            {
                set
                {
                    cantitate = value;
                    OnPropertyChanged("cantitate");
                }
                get
                {
                    return cantitate;
                }
            }
            public string ToString()
            {
                { return denumire + cantitate; }
            }

        }

        databaseWPFEntities1 contex;

        private List<string> categorii;
        public List<string> Categorii
        {
            set
            {
                categorii = value;
                OnPropertyChanged("categorii");
            }
            get
            {
                return categorii;
            }
        }


        private List<string> preparate;
        public List<string> Preparate
        {
            set
            {
                preparate = value;
                OnPropertyChanged("preparate");
            }
            get
            {
                return preparate;
            }
        }

        private List<string> preparateCurente;
        public List<string> PreparateCurente
        {
            set
            {
                preparateCurente = value;
                OnPropertyChanged("preparateCurente");
            }
            get
            {
                return preparateCurente;
            }
        }

        List<CurentMenu> menu;
        public List<CurentMenu> Menu
        {
            set
            {
                menu = value;
                OnPropertyChanged("menu");
            }
            get
            {
                return menu;
            }
        }

        private string quantity = "0";
        public string Quantity
        {
            set
            {
                quantity = value;
                OnPropertyChanged("quantity");

            }
            get
            {
                return quantity;
            }
        }

        private string denumire = "";
        public string Denumire
        {
            set
            {
                denumire = value;
                OnPropertyChanged("denumire");

            }
            get
            {
                return denumire;
            }
        }

        private bool EditMenu = false;

        MainViewModel.MeniulPret MeniulPret;
        int id;
        public AddEdditMeniuViewModel()
        {
            contex = new databaseWPFEntities1();
            Categorii = new List<string>();
            Preparate = new List<string>();
            PreparateCurente = new List<string>();
            initializare();
        }

        public AddEdditMeniuViewModel(MainViewModel.MeniulPret meniulPret)
        {
            contex = new databaseWPFEntities1();
            Categorii = new List<string>();
            Preparate = new List<string>();
            PreparateCurente = new List<string>();
            Denumire = meniulPret.Meniu.denumire;
            MeniulPret = meniulPret;
            id = MeniulPret.Meniu.id_meniu;
            initializare2();
        }

        public void initializare()
        {
            var res = contex.GetAllCategorii();
            var result = res.Select(x => new GetAllCategorii_Result
            {
                denumire = x.denumire,
                id_categorie = x.id_categorie
            }
            ).ToList();
            List<string> l = new List<string>();
            for (int i = 0; i < result.Count; i++)
            {
                var aux = result.ElementAt(i).denumire;
                l.Add(aux);
            }
            Categorii = l;


            var res1 = contex.SPGetPreparate();
            var resul1 = res1.Select(x1 => new SPGetPreparate_Result
            {
                cantintate_portie = x1.cantintate_portie,
                cantitate_restaurant = x1.cantitate_restaurant,
                denumire = x1.denumire,
                id_categorie = x1.id_categorie,
                id_preparat = x1.id_preparat,
                pret = x1.pret

            }).ToList();
            List<string> l1 = new List<string>();
            for (int i = 0; i < resul1.Count; i++)
            {
                var aux = resul1.ElementAt(i).denumire;
                l1.Add(aux);
            }
            Preparate = l1;

        }

        public void initializare2()
        {
            EditMenu = true;
            var res = contex.GetAllCategorii();
            var result = res.Select(x => new GetAllCategorii_Result
            {
                denumire = x.denumire,
                id_categorie = x.id_categorie
            }
            ).ToList();
            List<string> l = new List<string>();
            for (int i = 0; i < result.Count; i++)
            {
                var aux = result.ElementAt(i).denumire;
                l.Add(aux);
            }
            Categorii = l;

            var res1= contex.SPGetPreparateByMenu(Denumire);
            var resul1 = res1.Select(x1 => new SPGetPreparateByMenu_Result
            {
                denumire=x1.denumire,
                cantitate=x1.cantitate,
                cantitate_restaurant=x1.cantitate_restaurant,
                pret=x1.pret
            }).ToList();


            List<CurentMenu> men = new List<CurentMenu>();
            List<string> listPrep = new List<string>();
            for (int i = 0; i < resul1.Count; i++)
            {
                CurentMenu mn = new CurentMenu();
                mn.Denumire = resul1.ElementAt(i).denumire;
                mn.Cantitate = int.Parse(resul1.ElementAt(i).cantitate.ToString());
                listPrep.Add(resul1.ElementAt(i).denumire);
                men.Add(mn);
            }
            Menu = new List<CurentMenu>();
            Menu = men;
            OnPropertyChanged("menu");
            
            PreparateCurente = listPrep;

            var res2 = contex.SPGetPreparate();
            var resul2 = res2.Select(x1 => new SPGetPreparate_Result
            {
                cantintate_portie = x1.cantintate_portie,
                cantitate_restaurant = x1.cantitate_restaurant,
                denumire = x1.denumire,
                id_categorie = x1.id_categorie,
                id_preparat = x1.id_preparat,
                pret = x1.pret

            }).ToList();
            List<string> l1 = new List<string>();
            for (int i = 0; i < resul2.Count; i++)
            {
                var aux = resul2.ElementAt(i).denumire;
                l1.Add(aux);
            }

            for(int i=0;i<l1.Count;i++)
            {
                for(int j =0;j<resul1.Count;j++)
                {
                    if(l1.ElementAt(i)==resul1.ElementAt(j).denumire)
                    {
                        l1.RemoveAt(i);
                    }
                }
            }

            Preparate = l1;

        }

        public List<CurentMenu> CreateCurentMenu(List<string> val)
        {
            List<CurentMenu> men = new List<CurentMenu>();
            
            for (int i=0;i<val.Count;i++)
            {
                CurentMenu mn = new CurentMenu();
                mn.Denumire = val.ElementAt(i);
                if (Menu != null)
                {
                    if (Menu.Count != 0)
                    {
                        if (Menu.Count >= i)
                        {

                            for (int j = 0; j < Menu.Count; j++)
                            {
                                if (mn.Denumire == Menu.ElementAt(j).Denumire)
                                {
                                    mn.Cantitate = Menu.ElementAt(j).Cantitate;
                                }
                            }

                        }
                    }
                }
                men.Add(mn);
            }
            return men;
        }
        

        private ICommand add;
        public ICommand Add => add = new RelayCommand(o =>
        {
            if(o==null)
            {
                MessageBox.Show("Trebuie selectat un preparat!");
            }
            else { 
                List<string> preparateaux = preparate;
                List<string> preparateCurenteAux = preparateCurente;
                var name = o.ToString();
                Preparate = new List<string>();
                PreparateCurente = new List<string>();
                if (!PreparateCurente.Contains(name))
                {
                    preparateCurenteAux.Add(name);
                    preparateaux.Remove(name);

                    Preparate = preparateaux;
                    PreparateCurente = preparateCurenteAux;
                    //menu = new List<CurentMenu>();
                    //Menu = new List<CurentMenu>();
                    Menu = CreateCurentMenu(PreparateCurente);
                }
                OnPropertyChanged("Menu");
                OnPropertyChanged("menu");
                OnPropertyChanged("preparate");
                OnPropertyChanged("preparateCurente");
                OnPropertyChanged("Preparate");
                OnPropertyChanged("PreparateCurente");
            }
        });

        private ICommand remove;
        public ICommand Remove => remove = new RelayCommand(o =>
        {
            if (o == null)
            {
                MessageBox.Show("Trebuie selectat un preparat!");
            }
            else
            {
                List<string> preparateaux = preparate;
                List<string> preparateCurenteAux = preparateCurente;
                Preparate = new List<string>();
                PreparateCurente = new List<string>();
                var name = ((CurentMenu)o).Denumire;
                if (!Preparate.Contains(name))
                {
                    preparateCurenteAux.Remove(name);
                    preparateaux.Add(name);

                    Preparate = preparateaux;
                    PreparateCurente = preparateCurenteAux;
                    //Menu = new List<CurentMenu>();
                    Menu = CreateCurentMenu(PreparateCurente);
                }


                OnPropertyChanged("preparate");
                OnPropertyChanged("preparateCurente");
                OnPropertyChanged("Preparate");
                OnPropertyChanged("PreparateCurente");
            }
        });

        


        private ICommand set;
        public ICommand Set => set = new RelayCommand(o =>
        {
            if(o!=null)
            {
                var name = ((CurentMenu)o).Denumire;
                List<CurentMenu> mn = menu;
                Menu = new List<CurentMenu>();
                for (int i=0;i<mn.Count;i++)
                {
                    if(mn.ElementAt(i).Denumire==name)
                    {
                        mn.ElementAt(i).Cantitate = int.Parse(Quantity);
                    }
                }
                Menu = mn;
            }
            else
            {
                MessageBox.Show("Trebuie selectat un preparat!");
            }
            //Menu = new List<CurentMenu>();
            //Menu = CreateCurentMenu(PreparateCurente);

        });

        private ICommand exit;

        public ICommand Exit => exit = new RelayCommand(o => ((Window)o).Close());


        private ICommand insert;

        public ICommand Insert => insert = new RelayCommand(o =>
        {
            if (o != null)
            {
                if (EditMenu == false)
                {
                    contex.CreateMenu(Denumire, o.ToString());

                    for (int i = 0; i < Menu.Count; i++)
                    {
                        contex.CreateMenuPreparat(Denumire, Menu.ElementAt(i).Denumire, Menu.ElementAt(i).Cantitate);
                    }
                    MessageBox.Show("Meniul a fost creat!");
                }
                else
                {
                    contex.UpdateMeniu(Denumire, o.ToString(), id);

                    contex.DeleteMeniuPreparate(Denumire);
                    for (int i = 0; i < Menu.Count; i++)
                    {
                        contex.CreateMenuPreparat(Denumire, Menu.ElementAt(i).Denumire, Menu.ElementAt(i).Cantitate);
                    }


                    MessageBox.Show("Meniul a fost updatat!");
                }
            }
            else
            {

                MessageBox.Show("Trebuie selectat un preparat!");

            }

        });

    }
}
