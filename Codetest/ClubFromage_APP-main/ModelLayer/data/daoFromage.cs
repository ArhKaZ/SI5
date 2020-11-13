
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Bcpg;
using System;
using System.IO;
using System.Globalization;
using CsvHelper;
using Model.data;
using Model.buisness;
using System.Collections.Generic;
using System.Data;
using CsvHelper.TypeConversion;

namespace Model.data
{


    public class daoFromage
    {
        private DBAL _mydbal;
        private daoPays _myDaoPays;

        public daoFromage(DBAL BDD, daoPays DaoPays)
        {
            _mydbal = BDD;
            _myDaoPays = DaoPays;
        }

        public void Insert(Fromage Unfromage)
        {
            Console.WriteLine("INSERT INTO fromage (id,pays_origine_id,nom,creation,image) values (" + Unfromage.Id + ", " + Unfromage.Idpays.Id + ", '" + Unfromage.Nom + "', " + Unfromage.Creation + ", '" + Unfromage.Image + "') ;");
            _mydbal.Insert("INSERT INTO fromage (id,pays_origine_id,nom,creation,image) values (" + Unfromage.Id + ", " + Unfromage.Idpays.Id + ", '" + Unfromage.Nom + "', '" + Unfromage.Creation + "', '" + Unfromage.Image + "') ;");

        }

        public void Update(Fromage UnFromage)
        {
            _mydbal.Insert("UPDATE fromage set id = " + UnFromage.Id + ", id_pays_origin = " + UnFromage.Idpays.Id + ", nom = " + UnFromage.Nom + ",creation = '" + UnFromage.Creation + "', image = " + UnFromage.Image + " Where id = " + UnFromage.Id + " ;");

        }

        public void Delete(Fromage UnFromage)
        {
            _mydbal.Insert("DELETE FROM fromage where " + UnFromage.Id + " ;");

        }
        

        public List<Fromage> SelectAll()
        {
            List<Fromage> lesfromage = new List<Fromage>();
            foreach (DataRow DataR in _mydbal.SelectALL("fromage").Rows)
            {
                lesfromage.Add(new Fromage
                    (
                    (int)DataR["id"],
                    _myDaoPays.selectByID((int)DataR["pays_origine_id"]),
                    (string)DataR["nom"],
                    (DateTime)DataR["creation"],
                    (string)DataR["image"]
                    )
                    );

            }

            return lesfromage;
        }
        public Fromage SelectByName(string UnFromage)
        {
            DataRow DataR = _mydbal.SelectByField("fromage", "nom like '" + UnFromage + "'").Rows[0];
            return new Fromage(
                (int)DataR["id"],
                _myDaoPays.selectByID((int)DataR["pays_origine_id"]),
                (string)DataR["nom"],
                    (DateTime)DataR["creation"],
                    (string)DataR["image"]
                );
        }
        public Fromage SelectByID(int IDPays)
        {
            DataRow DataR = _mydbal.SelectByID("fromage", IDPays);
            return new Fromage(
                 (int)DataR["id"],
                 _myDaoPays.selectByID((int)DataR["pays_origine_id"]),
                 (string)DataR["nom"],
                     (DateTime)DataR["creation"],
                     (string)DataR["image"]
                 );

        }
        public void MainCSV()
        {
            using (var reader = new StreamReader("fromages.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                var record = new Fromage();
                var records = csv.EnumerateRecords(record);

                foreach (var item in records)
                {
                    this.Insert(item);
                }
            }
            Console.WriteLine("importation de fromage réussit");
        }

    }
}