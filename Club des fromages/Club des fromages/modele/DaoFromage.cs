using Club_des_fromages.metier;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Club_des_fromages.modele
{
    class DaoFromage : Fromage
    {

        public void InsertFromage(DaoFromage unFromage)
        {
            dbal mydbal = new dbal();
            mydbal.Insert("Fromage VALUES (" + unFromage.id + ", " + unFromage.pays_origine_id + ", '" + unFromage.nom + "' , " + unFromage.creation + "," + unFromage.Image);
        }

        public void UpdateFromage(DaoFromage unFromage,string valeurAchange, string newValue)
        {
            dbal mydbal = new dbal();
            mydbal.Update("Fromage SET" + valeurAchange + " = '" + newValue + "' where id ='" + unFromage.id + "'");
        }

        public void DeleteFromage(DaoFromage unFromage)
        {
            dbal mydbal = new dbal();
            mydbal.Delete("Fromage WHERE id = '" + unFromage.id + "'");
        }
    }
}
