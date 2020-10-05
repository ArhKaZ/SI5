using System;
using System.Collections.Generic;
using Club_des_fromages.metier;
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
            DaoPays Suisse = new DaoPays(mydbal);
            Suisse.InsertByFile("D:/SylvainLuiset/SLAM5/Club des fromages/Club des fromages/pays.csv");

            
            //mydbal.Delete("Pays WHERE id = '1'");
            //mydbal.Delete("Fromage WHERE id ='1'");
            //mydbal.Delete("Pays WHERE id='2'");
            //mydbal.ExecQuery("INSERT INTO Pays (id, nom) VALUES (1, 'FRANCE')");
            //mydbal.ExecQuery("INSERT INTO Fromage (id, pays_origine_id, nom, creation, image) VALUES (1, 1, 'Compté', '1843-02-10', 'pasimage')");
            //mydbal.Insert("Pays (id, nom) VALUES (2, 'Angleterre')");
            //mydbal.Update("Fromage SET pays_origine_id = '2' WHERE id ='1'");
            //mydbal.Select("* FROM Pays");
            //mydbal.Count("(*) FROM Pays");
            //mydbal.Delete("Pays WHERE id = '2'");

            ////InsertPays par DAO
            //Pays ar = new Pays(5, "Suisse");
            //Pays ad = new Pays(5, "Jordanie");
            //DaoPays Suisse = new DaoPays(mydbal);
            //Suisse.InsertPays(ar);

            ////UpdatePays par DAO
            //Suisse.UpdatePays(ad);

            ////DeletePays par DAO
            //Suisse.DeletePays(ar);

            ////Utilisation CSV
           

        }
    }
}
