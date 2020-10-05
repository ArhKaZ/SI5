using System;
using System.Collections.Generic;
using System.Text;

namespace Club_des_fromages.metier
{
    class Pays
    {
        protected int id;
        protected string nom;

        public Pays(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
