using System;
using System.Windows.Data;
using System.ComponentModel;
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
        private Fromage selectedFromage = new Fromage();
        private Fromage activFromage = new Fromage();

        //déclaration des listes...à compléter avec les fromages
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Fromage> ListFromages { get => listFromages; set => listFromages = value; }
        //déclaration des propriétés avec OnPropertyChanged("nom_propriété_bindée")

        public Fromage SelectedFromage
        {
            get => selectedFromage;
            set
            {
                if (selectedFromage != value)
                {
                    selectedFromage = value;
                    OnPropertyChanged("SelectedFromage");
                    if (selectedFromage != null)
                    {
                        ActivFromage = selectedFromage;
                    }
                }
            }
        }

        public Fromage ActivFromage
        {
            get => activFromage;
            set
            {
                if (activFromage != value)
                {
                    activFromage = value;
                    OnPropertyChanged("Name");
                    OnPropertyChanged("Origin");
                    OnPropertyChanged("Creation");
                }
            }
        }


        public string Name
        {
            get => activFromage.Name;
            set
            {
                if (activFromage.Name != value)
                {
                    activFromage.Name = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                }
            }
        }

        public DateTime Creation
        {
            get => activFromage.Creation;
            set
            {
                if (activFromage.Creation != value)
                {
                    activFromage.Creation = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Creation");
                }
            }
        }
        public Pays Origin
        {
            get => activFromage.Origin;
            set
            {
                if (activFromage.Origin != value)
                {
                    activFromage.Origin = value;

                     OnPropertyChanged("Origin");
                        
                    
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    
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
            foreach (Fromage f in listFromages)
            {
                foreach (Pays p in listPays)
                {
                    if (f.Origin.Name == p.Name)
                    {
                        f.Origin = p;
                    }

                }

            }
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
