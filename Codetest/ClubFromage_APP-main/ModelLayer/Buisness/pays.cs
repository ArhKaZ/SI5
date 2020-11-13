using System;
namespace Model.buisness
{


    public class Pays
    {
        private int _id;
        private string _nom;
        public Pays(int UnID, string NomPays)
        {
            _id = UnID;
            _nom = NomPays;


        }
        public Pays()
        {
            _id = 0;
            _nom = "";
        }
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
    }
}