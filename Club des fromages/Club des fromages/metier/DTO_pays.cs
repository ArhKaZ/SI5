using System;
using System.Collections.Generic;
using System.Text;

namespace Club_des_fromages.metier
{
    class DTO_pays
    {
        private int id;
        private string nom;

        public DTO_pays(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
