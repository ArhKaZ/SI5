using System;
using System.IO;
using Club_des_fromages.metier;
using Club_des_fromages.modele;
using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Club_des_fromages.modele
{
    class PaysConverter
    {
        private dbal mydbal;
        
       
        public Pays ConvertFromString(string t)
        { 
            return new Pays(
                int.Parse(t.Substring(0, t.IndexOf(';'))),
                t.Substring(t.IndexOf(';') + 1)
                );
        }

        public string ConvertToString(Pays unp)
        {
            return unp.Id + ";" + unp.Nom;
        }
    }
}
