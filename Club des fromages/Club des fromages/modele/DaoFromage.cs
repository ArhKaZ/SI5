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
    class DaoFromage
    {
        private dbal mydbal;
        public DaoFromage(dbal mydbal)
        {
            this.mydbal = mydbal;     
        }

        public void InsertFromage(Fromage unFromage)
        {
            mydbal.Insert("Fromage VALUES (" + unFromage.Id + ", " + unFromage.Pays_origine_id + ", '" + unFromage.Nom + "' , " + unFromage.Creation + "," + unFromage.Image);
        }

        public void UpdateFromage(Fromage unFromage)
        {
            mydbal.Update("Pays SET id = '" + unFromage.Id + "', pays_orignine_id ='" + unFromage.Pays_origine_id + "', nom = '" + unFromage.Nom + "', creation = '" + unFromage.Creation + "', image = '" + unFromage.Image + "'");
        }

        public void DeleteFromage(Fromage unFromage)
        {
            mydbal.Delete("Fromage WHERE id = '" + unFromage.Id + "'");
        }

        public void InsertByFile(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = new ibf_Pays();
                var records = csv.EnumerateRecords(record);
                csv.Configuration.PrepareHeaderForMatch = (nom, id) => nom.ToLower();
                foreach (var e in records)
                {
                    mydbal.Insert("Pays VALUES (" + e.Id + ", '" + e.Nom + "'");
                }
            }
        }
    }
}
