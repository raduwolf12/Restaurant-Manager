using Restaurant.Commands;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Restaurant.ViewModels
{
    class AddEdditPreparatViewModel:BaseVM
    {
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

        private List<string> alergeni;
        public List<string> Alergeni
        {
            set
            {
                alergeni = value;
                OnPropertyChanged("alergeni");
            }
            get
            {
                return alergeni;
            }
        }

        private List<string> alergeniCurenti;
        public List<string> AlergeniCurenti
        {
            set
            {
                alergeniCurenti = value;
                OnPropertyChanged("alergeniCurenti");
            }
            get
            {
                return alergeniCurenti;
            }
        }


        private string denumire="";
        private string pret = "";
        private string gramaj = "";
        private string cantitateMagazin = "";
        private string img1 = "";
        private string img2 = "";
        private string img3 = "";

        private bool EditeMode = false;

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
        public string Pret
        {
            set
            {
                pret = value;
                OnPropertyChanged("pret");
            }
            get
            {
                return pret;
            }
        }
        public string Gramaj
        {
            set
            {
                gramaj = value;
                OnPropertyChanged("gramaj");
            }
            get
            {
                return gramaj;
            }
        }
        public string CantitateMagazin
        {
            set
            {
                cantitateMagazin = value;
                OnPropertyChanged("cantitateMagazin");
            }
            get
            {
                return cantitateMagazin;
            }
        }
        public string Img1
        {
            set
            {
                img1 = value;
                OnPropertyChanged("img1");
            }
            get
            {
                return img1;
            }
        }
        public string Img2
        {
            set
            {
                img2 = value;
                OnPropertyChanged("img2");
            }
            get
            {
                return img2;
            }
        }
        public string Img3
        {
            set
            {
                img3 = value;
                OnPropertyChanged("img3");
            }
            get
            {
                return img3;
            }
        }

        MainViewModel.Parat preparat;
        public MainViewModel.Parat Preparat
        {
            set
            {
                preparat = value;
                OnPropertyChanged("preparat");
            }
            get
            {
                return preparat;
            }
        }

        private int id;

        public AddEdditPreparatViewModel()
        {
            Categorii = new List<string>();
            AlergeniCurenti = new List<string>();
            Alergeni = new List<string>();

            contex = new databaseWPFEntities1();
            initializare();

        }
        public AddEdditPreparatViewModel(MainViewModel.Parat parat)
        {
            Categorii = new List<string>();
            AlergeniCurenti = new List<string>();
            Alergeni = new List<string>();
            Preparat = parat;
            contex = new databaseWPFEntities1();

            Denumire = parat.Name.denumire;
            Pret = parat.Name.pret.ToString();
            Gramaj = parat.Name.cantintate_portie.ToString();
            CantitateMagazin = parat.Name.cantitate_restaurant.ToString();
            Img1 = parat.poze.ElementAt(0);
            if(parat.poze.Count>1)
            {
                Img2 = parat.poze.ElementAt(1);
            }
            if (parat.poze.Count >2)
            {
                Img3 = parat.poze.ElementAt(2);
            }
            id= parat.Name.id_preparat;
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


            var res1 = contex.GetAllAlergeni();
            var resul1 = res1.Select(x1 => new GetAllAlergeni_Result
            {
                denumire=x1.denumire,
                id_alergeni=x1.id_alergeni

            }).ToList();
            List<string> l1 = new List<string>();
            for (int i = 0; i < resul1.Count; i++)
            {
                var aux = resul1.ElementAt(i).denumire;
                l1.Add(aux);
            }
            Alergeni = l1;

        }

        public void initializare2()
        {
            EditeMode = true;
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


            var res1 = contex.GetAllAlergeni();
            var resul1 = res1.Select(x1 => new GetAllAlergeni_Result
            {
                denumire = x1.denumire,
                id_alergeni = x1.id_alergeni

            }).ToList();
            List<string> l1 = new List<string>();
            for (int i = 0; i < resul1.Count; i++)
            {
                var aux = resul1.ElementAt(i).denumire;
                l1.Add(aux);
            }
            

            AlergeniCurenti = GetAlergeniPreparat(Denumire);
            for(int i =0;i<AlergeniCurenti.Count;i++)
            {
                for(int j=0;j<l1.Count;j++)
                {
                    if(l1.ElementAt(j)==AlergeniCurenti.ElementAt(i))
                    {
                        l1.RemoveAt(j);
                    }
                }
            }

            Alergeni = l1;
        }


        public List<string> GetAlergeniPreparat(string preparat)
        {
            var alergeni = contex.SPGetAllergeniForPreparat(preparat);


            var result = alergeni.Select(x => new { Name = x })
            .AsEnumerable() //Force EF to materialize the result here
            .Select(x => new List<string> { x.Name }) //Manipulate the result in memory
            .ToList();


            List<string> li = new List<string>();
            for(int i =0;i<result.Count;i++)
            {
                var l =result.ElementAt(i).ElementAt(0);
                li.Add(l);
            }

            return li;
        }
       

        private ICommand add;
        public ICommand Add => add = new RelayCommand(o =>
        {

            List<string> preparateaux = alergeni;
            List<string> preparateCurenteAux = alergeniCurenti;
            Alergeni = new List<string>();
            AlergeniCurenti = new List<string>();
            var name = o.ToString();
            if (!AlergeniCurenti.Contains(name))
            {
                preparateCurenteAux.Add(name);
                preparateaux.Remove(name);

                Alergeni = preparateaux;
                AlergeniCurenti = preparateCurenteAux;
            }

            OnPropertyChanged("preparate");
            OnPropertyChanged("preparateCurente");
            OnPropertyChanged("Preparate");
            OnPropertyChanged("PreparateCurente");

        });

        private ICommand remove;
        public ICommand Remove => remove = new RelayCommand(o =>
        {

            List<string> preparateaux = alergeni;
            List<string> preparateCurenteAux = alergeniCurenti;
            Alergeni = new List<string>();
            AlergeniCurenti = new List<string>();
            var name = o.ToString();
            if (!Alergeni.Contains(name))
            {
                preparateCurenteAux.Remove(name);
                preparateaux.Add(name);

                Alergeni = preparateaux;
                AlergeniCurenti = preparateCurenteAux;
            }


            OnPropertyChanged("preparate");
            OnPropertyChanged("preparateCurente");
            OnPropertyChanged("Preparate");
            OnPropertyChanged("PreparateCurente");

        });

        private ICommand exit;

        public ICommand Exit => exit = new RelayCommand(o => ((Window)o).Close());

        private ICommand insert;

        public ICommand Insert => insert = new RelayCommand(o => 
        {
            contex = new databaseWPFEntities1();
            if (o != null)
            {
                if (EditeMode == false)
                {
                    contex.CreatePreparat(Denumire, double.Parse(Pret), int.Parse(Gramaj), int.Parse(CantitateMagazin), o.ToString());

                    for (int i = 0; i < AlergeniCurenti.Count; i++)
                    {
                        contex.CreateAlergeniPreparat(Denumire, Alergeni.ElementAt(i));
                    }

                    if (Img1 != "")
                    {
                        contex.CreatePoza(Img1);
                        contex.CreatePozePreparat(Denumire, Img1);
                    }
                    if (Img2 != "")
                    {
                        contex.CreatePoza(Img2);
                        contex.CreatePozePreparat(Denumire, Img2);
                    }
                    if (Img3 != "")
                    {
                        contex.CreatePoza(Img3);
                        contex.CreatePozePreparat(Denumire, Img3);
                    }


                    MessageBox.Show("Preparatul a fost creat!");
                }
                else
                {
                    //contex.CreatePreparat(Denumire, double.Parse(Pret), int.Parse(Gramaj), int.Parse(CantitateMagazin), o.ToString());
                    contex.UpdatePreparat(Denumire, double.Parse(Pret), int.Parse(Gramaj), int.Parse(CantitateMagazin), o.ToString(), id);
                    contex.DeletePozePreparat(Denumire);
                    contex.DeleteAlergeniPreparat(Denumire);

                    for (int i = 0; i < AlergeniCurenti.Count; i++)
                    {
                        contex.CreateAlergeniPreparat(Denumire, Alergeni.ElementAt(i));
                    }

                    if (Img1 != "")
                    {
                        contex.CreatePoza(Img1);
                        contex.CreatePozePreparat(Denumire, Img1);
                    }
                    if (Img2 != "")
                    {
                        contex.CreatePoza(Img2);
                        contex.CreatePozePreparat(Denumire, Img2);
                    }
                    if (Img3 != "")
                    {
                        contex.CreatePoza(Img3);
                        contex.CreatePozePreparat(Denumire, Img3);
                    }


                    MessageBox.Show("Preparatul a fost updatat!");
                }
            }

        });


    }
}
