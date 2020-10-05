using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Club_des_fromages.modele
{
    class Pays
    {
        private int id;
        private string nom;

        public Pays(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public void InsertPays(Pays unPays)
        {
            dbal mydbal = new dbal();
            mydbal.Insert("Pays (id, nom) VALUES (" + unPays.id + ", '" + unPays.nom + "'");
        }

        public void UpdatePays(Pays unPays, string valeurAchange, string newValue)
        {
            dbal mydbal = new dbal();
            mydbal.Update("Fromage SET" + valeurAchange + " = '" + newValue + "' where id ='" + unPays.id + "'");
        }

        public void DeletePays(Pays unPays)
        {
            dbal mydbal = new dbal();
            mydbal.Delete("Fromage WHERE id = '" + unPays.id + "'");
        }
    }
}
