using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Club_des_fromages.modele
{
    class Fromage
    {
        private int id;
        private string pays_origine_id;
        private string nom;
        private int creation;
        private string image;

        public Fromage(int id, string pays_origine_id, string nom, int creation, string image)
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

        public void InsertFromage(Fromage unFromage)
        {
            dbal mydbal = new dbal();
            mydbal.Insert("Fromage VALUES (" + unFromage.id + ", " + unFromage.pays_origine_id + ", '" + unFromage.nom + "' , " + unFromage.creation + "," + unFromage.Image);
        }

        public void UpdateFromage(Fromage unFromage,string valeurAchange, string newValue)
        {
            dbal mydbal = new dbal();
            mydbal.Update("Fromage SET" + valeurAchange + " = '" + newValue + "' where id ='" + unFromage.id + "'");
        }

        public void DeleteFromage(Fromage unFromage)
        {
            dbal mydbal = new dbal();
            mydbal.Delete("Fromage WHERE id = '" + unFromage.id + "'");
        }
    }
}
