using Club_des_fromages.metier;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Club_des_fromages.modele
{
    class DaoFromage
    {
        private dbal mydbal = new dbal();
        public DaoFromage(dbal mydbal)
        {
            this.mydbal = mydbal;     
        }

        public void InsertFromage(Fromage unFromage)
        {
            mydbal.Insert("Fromage VALUES (" + unFromage.Id + ", " + unFromage.Pays_origine_id + ", '" + unFromage.Nom + "' , " + unFromage.Creation + "," + unFromage.Image);
        }

        public void UpdateFromage(Fromage unFromage,string valeurAchange, string newValue)
        {
            mydbal.Update("Fromage SET" + valeurAchange + " = '" + newValue + "' where id ='" + unFromage.Id + "'");
        }

        public void DeleteFromage(Fromage unFromage)
        {
            mydbal.Delete("Fromage WHERE id = '" + unFromage.Id + "'");
        }
    }
}
