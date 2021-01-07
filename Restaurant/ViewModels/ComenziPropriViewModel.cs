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
    class ComenziPropriViewModel:BaseVM
    {
        databaseWPFEntities1 contex;
        private List<GetComenziFull_Result> comenzi;
        public List<GetComenziFull_Result> Comenzi
        {
            set
            {
                comenzi = value;
                OnPropertyChanged("comenzi");
            }
            get
            {
                return comenzi;
            }
        }

        private List<ComenziF> comenziF;
        public List<ComenziF> ComenziFs
        {
            set
            {
                comenziF = value;
                OnPropertyChanged("comenziF");
            }
            get
            {
                return comenziF;
            }
        }

        private List<GetAllStatus_Result> statusuri;
        public List<GetAllStatus_Result> Statusuri
        {
            set
            {
                statusuri = value;
                OnPropertyChanged("statusuri");
            }
            get
            {
                return statusuri;
            }
        }
        private GetAllStatus_Result status;
        public GetAllStatus_Result Status
        {
            set
            {
                status = value;
                OnPropertyChanged("status");
            }
            get
            {
                return status;
            }
        }
        public ComenziPropriViewModel()
        { }
        public ComenziPropriViewModel(string email)
        {
            contex = new databaseWPFEntities1();
            List<GetComenziFull_Result> Comenzi = new List<GetComenziFull_Result>();
            List<ComenziF> ComenziFs = new List<ComenziF>();
            List<GetAllStatus_Result> Statusuri = new List<GetAllStatus_Result>();
            init(email);
            EMail = email;
        }
        private string EMail;
        public class ComenziF
        {
            GetComenziFull_Result comanda;
            string date;
            public GetComenziFull_Result Comanda
            {
                set
                {
                    comanda = value;
                }
                get
                {
                    return comanda;
                }
            }
            public string Date
            {
                set
                {
                    date = value;
                }
                get
                {
                    return date;
                }
            }


        }

        public void init(string email)
        {
            var res = contex.GetComenziByEmail(email);
            var result = res.Select(x => new GetComenziFull_Result
            {
                Adress = x.Adress.Trim(),
                data_coamnda = x.data_coamnda,
                id_comanda = x.id_comanda,
                id_user = x.id_user,
                Name = x.Name.Trim()
                ,
                nume = x.nume.Trim(),
                pret = x.pret,
                Surname = x.Surname.Trim()

            }).ToList();


            List<ComenziF> cp = new List<ComenziF>();
            for (int i = 0; i < result.Count; i++)
            {
                ComenziF f = new ComenziF();
                f.Comanda = result.ElementAt(i);
                long getLong = BitConverter.ToInt64(result.ElementAt(i).data_coamnda, 0);
                //DateTime getNow = DateTime.FromBinary(getLong);
                DateTime localDate = DateTime.Now;
                f.Date = localDate.ToLongTimeString();
                cp.Add(f);
            }
            Comenzi = result;
            ComenziFs = cp;


            var res1 = contex.GetAllStatus();
            var result1 = res1.Select(x => new GetAllStatus_Result
            {
                id_status = x.id_status,
                nume = x.nume
            }).ToList();

            Statusuri = result1;


        }


        private ICommand set;
        public ICommand Set => set = new RelayCommand(o =>
        {
            if (o == null)
            {
                MessageBox.Show("Selecteaza o comanda!");
            }
            else
            {
                
                var user = ((ComenziF)o);
                if (user.Comanda.nume == "inregistrata")
                {
                    contex.UpdateComandaStatus(user.Comanda.id_user, "anulata", user.Comanda.id_comanda);

                    ComenziFs = new List<ComenziF>();
                    Comenzi = new List<GetComenziFull_Result>();
                    //comenziF = new List<ComenziF>();
                    //comenzi = new List<GetComenziFull_Result>();
                    var res = contex.GetComenziByEmail(EMail);
                    var result = res.Select(x => new GetComenziFull_Result
                    {
                        Adress = x.Adress.Trim(),
                        data_coamnda = x.data_coamnda,
                        id_comanda = x.id_comanda,
                        id_user = x.id_user,
                        Name = x.Name.Trim()
                        ,
                        nume = x.nume.Trim(),
                        pret = x.pret,
                        Surname = x.Surname.Trim()

                    }).ToList();


                    List<ComenziF> cp = new List<ComenziF>();
                    for (int i = 0; i < result.Count; i++)
                    {
                        ComenziF f = new ComenziF();
                        f.Comanda = result.ElementAt(i);
                        long getLong = BitConverter.ToInt64(result.ElementAt(i).data_coamnda, 0);
                        DateTime localDate = DateTime.Now;
                        f.Date = localDate.ToLongTimeString();
                        cp.Add(f);
                    }
                    Comenzi = result;
                    ComenziFs = cp;
                    OnPropertyChanged("ComenziFs");
                }
                else
                {
                    MessageBox.Show("Comanda nu poate fii anulata!");
                }
            }
        });
        private ICommand exit;

        public ICommand Exit => exit = new RelayCommand(o => ((Window)o).Close());

    }
}
