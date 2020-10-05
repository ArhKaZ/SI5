using Club_des_fromages.metier;
using CsvHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Ubiety.Dns.Core;

namespace Club_des_fromages.modele
{
    class DaoPays 
    {
        private dbal mydbal;
        public DaoPays(dbal undbal)
        {
            this.mydbal = undbal;
        }

        public void InsertPays(Pays unPays)
        {
            mydbal.Insert("Pays (id, nom) VALUES (" + unPays.Id + ", '" + unPays.Nom + "'");
        }

        public void UpdatePays(Pays unPays)
        {
            mydbal.Update("Pays SET id = '" + unPays.Id + "', nom ='" + unPays.Nom + "'");
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
                csv.Configuration.PrepareHeaderForMatch = (nom, id) => nom.ToLower();
                    var record = new ibf_Pays() ;
                var records = csv.EnumerateRecords(record);
                foreach (var e in records)
                {
                    mydbal.Insert("Pays VALUES (" + e.Id + ", '" + e.Nom + "'");
                }
            }
        }
    }
}
