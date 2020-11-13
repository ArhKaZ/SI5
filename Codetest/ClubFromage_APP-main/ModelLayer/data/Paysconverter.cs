using System;
using System.Collections.Generic;
using System.Text;
using Model.buisness;
using CsvHelper.Expressions;
using CsvHelper.TypeConversion;
using System.IO;
using Model.data;
using System.Globalization;
using System.Data;

namespace Model.data
{
    
    public class Paysconverter<T> : DefaultTypeConverter
    {
        public Pays ConvertFromString(string text)
        {
            return new Pays(
                int.Parse(text.Substring(0,text.IndexOf(';'))),
                text.Substring(text.IndexOf(';') + 1));
        }

        public string ConvertToString(Pays Unpays)
        {
            return Unpays.Id+";"+Unpays.Nom;
        }
    }
}
