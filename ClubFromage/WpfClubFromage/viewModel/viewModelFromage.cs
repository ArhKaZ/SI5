using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLayer.Business;
using ModelLayer.Data;
using WpfClubFromage.viewModel;

namespace WpfClubFromage.viewModel
{
    class viewModelFromage : viewModelBase
    {
        //déclaration des attributs ...à compléter
        private DaoPays vmDaoPays;
        private DaoFromage vmDaoFrom;
        private ICommand updateCommand;
        private ObservableCollection<Pays> listPays;
        private ObservableCollection<Fromage> listFromages;
        private Fromage monFromage = new Fromage(1,"Rebloch");

        //déclaration des listes...à compléter avec les fromages
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Fromage> ListFromages { get => listFromages; set => listFromages = value; }
        //déclaration des propriétés avec OnPropertyChanged("nom_propriété_bindée")
        //par exemple...
        public string Name
        {
            get => monFromage.Name;
            set
            {
                if (monFromage.Name != value)
                {
                    monFromage.Name = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                }
            }
        }

        public Pays lePays
        {
            get => monFromage.Origin;
            set
            {
                if (monFromage.Origin != value)
                {
                    monFromage.Origin = value;
                    OnPropertyChanged("Origin");
                }
            }
        }


    public DateTime Creation
        {
            get => monFromage.Creation;
            set
            {
                if (monFromage.Creation != value)
                {
                    monFromage.Creation = value;
                    OnPropertyChanged("Creation");
                }
            }
        }

        //déclaration du contructeur de viewModelFromage
        public viewModelFromage(DaoPays thedaopays, DaoFromage thedaofromage)
        {
            vmDaoPays = thedaopays;

            vmDaoFrom = thedaofromage;

            listPays = new ObservableCollection<Pays>(thedaopays.SelectAll());

            listFromages = new ObservableCollection<Fromage>(thedaofromage.SelectAll());

        }

        //Méthode appelée au click du bouton UpdateCommand
        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateFromage(), () => true);
                }
                return this.updateCommand;

            }

        }

        private void UpdateFromage()
        {
            
            
        }
    }
}
