using System;
using System.Collections.Generic;
using System.Text;

namespace Club_des_fromages.metier
{
    class DTO_Fromage
    {
        private int id;
        private string pays_origine_id;
        private string nom;
        private int creation;
        private string image;

        public DTO_Fromage(int id, string pays_origine_id, string nom, int creation, string image)
        {
            this.id = id;
            this.pays_origine_id = pays_origine_id;
            this.nom = nom;
            this.creation = creation;
            this.image = image;
        }

        public int Id { get => id; set => id = value; }
        public string Pays_origine_id { get => pays_origine_id; set => pays_origine_id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Creation { get => creation; set => creation = value; }
        public string Image { get => image; set => image = value; }
    }
}
