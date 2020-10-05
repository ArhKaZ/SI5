using System;
using System.Collections.Generic;
using Club_des_fromages.modele;
using MySql.Data.MySqlClient;
using Xceed.Wpf.Toolkit;

namespace Club_des_fromages
{
    class Program
    {
        static void Main(string[] args)
        {
           dbal mydbal = new dbal();
            mydbal.Delete("Pays WHERE id = '1'");
            mydbal.Delete("Fromage WHERE id ='1'");
            mydbal.Delete("Pays WHERE id='2'");
            mydbal.ExecQuery("INSERT INTO Pays (id, nom) VALUES (1, 'FRANCE')");
            mydbal.ExecQuery("INSERT INTO Fromage (id, pays_origine_id, nom, creation, image) VALUES (1, 1, 'Compté', '1843-02-10', 'pasimage')");
            mydbal.Insert("Pays (id, nom) VALUES (2, 'Angleterre')");
            mydbal.Update("Fromage SET pays_origine_id = '2' WHERE id ='1'");
            mydbal.Select("* FROM Pays");
            mydbal.Count("(*) FROM Pays");
            mydbal.Delete("Pays WHERE id = '2'");

            Pays ar = new Pays(5, "Suisse");
            ar.InsertPays(ar);

        }
    }
}
