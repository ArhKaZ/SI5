using Club_des_fromages.metier;
using CsvHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Club_des_fromages.modele
{
    class DaoPays 
    {
        private dbal mydbal = new dbal();
        public DaoPays(dbal undbal)
        {
            this.mydbal = undbal;
        }

        public void InsertPays(Pays unPays)
        {
            mydbal.Insert("Pays (id, nom) VALUES (" + unPays.Id + ", '" + unPays.Nom + "'");
        }

        public void UpdatePays(Pays unPays, string valeurAchange, string newValue)
        {
            mydbal.Update("Fromage SET" + valeurAchange + " = '" + newValue + "' where id ='" + unPays.Id + "'");
        }

        public void DeletePays(Pays unPays)
        {
            mydbal.Delete("Fromage WHERE id = '" + unPays.Id + "'");
        }

        public void InsertByFile(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<Pays> records = new List<Pays>();
                records = csv.GetRecords<Pays>;
            }
        }
    }
}
