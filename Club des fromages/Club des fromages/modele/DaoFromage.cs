using Club_des_fromages.metier;
using CsvHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        private DaoPays _daoPays;
        public DaoFromage(dbal undbal)
        {
            mydbal = undbal;
            _daoPays = new DaoPays(mydbal);
        }

        public void InsertFromage(Fromage unFromage)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values["id"] = unFromage.Id.ToString();
            values["pays_origine_id"] = unFromage.Pays_origine_id.ToString();
            values["nom"] = "'" + unFromage.Nom.Replace("'", "\\'") + "'";
            values["creation"] = "'" + unFromage.Creation.ToString("yyyy'-'MM'-'dd") + "'"; 
            values["image"] = "'" + unFromage.Image.Replace("'", "\\'") + "'";
            mydbal.Insert("fromage", values);
        }

        public void UpdateFromage(Fromage unFromage)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values["pays_origine_id"] = unFromage.Pays_origine_id.ToString();
            values["nom"] = "'" + unFromage.Nom.Replace("'", "\\'") + "'";
            values["creation"] = "'" + unFromage.Creation.ToString("yyyy'-'MM'-'dd") + "'";
            values["image"] = "'" + unFromage.Image.Replace("'", "\\'") + "'";
            mydbal.Update("fromage", values, "id = " + unFromage.Id);
        }

        public void DeleteFromage(Fromage unFromage)
        {
            mydbal.Delete("Fromage", "id = " + unFromage.Id);
        }
        public void insertfile(string path, string delimiter)
        {
            using (var reader = new StreamReader("fromage.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = delimiter;
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                Fromage record = new Fromage(); 
                var records = csv.EnumerateRecords(record);
                foreach (Fromage fr in records)
                {
                    this.InsertFromage(fr);
                }
            }
        }
        public List<Fromage> SelectAll()
        {
            List<Fromage> lesFro = new List<Fromage>();
            DataTable tableP = mydbal.SelectAll("Pays");
            DataTable tableF = mydbal.SelectAll("Fromage");
            foreach (DataRow dr in tableF.Rows)
            {
                lesFro.Add(new Fromage(
                    (int)dr["id"],
                    _daoPays.SelectById((int)dr["pays_origine_id"]),
                    (string)dr["nom"],
                    (DateTime)dr["Creation"],
                    (string)dr["image"]
                    ));
            }
            return lesFro;
        }
        public Fromage SelectByName(string nom)
        {
            DataRow dr = mydbal.SelectByfield("Fromage", "nom = '" + nom + "'").Rows[0];
            return new Fromage(
                (int)dr["id"],
                _daoPays.SelectById((int)dr["pays_origine_id"]),
                (string)dr["nom"],
                (DateTime)dr["creation"],
                (string)dr["image"])
                ;
        }

        public Fromage SelectById(int id)
        {
            DataRow dr = mydbal.DataRowSelectById("Pays", id);
            return new Fromage(
                (int)dr["id"],
                _daoPays.SelectById((int)dr["pays_origine_id"]),
                (string)dr["nom"],
                (DateTime)dr["creation"],
                (string)dr["image"]);
        }

    } 
}

