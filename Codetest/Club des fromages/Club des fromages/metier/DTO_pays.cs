using System;
using System.Collections.Generic;
using System.Text;

namespace Club_des_fromages.metier
{
    class Pays
    {
        private int _id;
        private string _nom;

        public Pays()
        {
            _id = 0;
            _nom = "";
        }
        public Pays(int id, string nom)
        {
            _id = id;
            _nom = nom;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
    }
}
