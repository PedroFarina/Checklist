using System;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Checklist.Classes.XML
{
    public static class XML
    {
        public static bool Serializar(this object lEntrada, string Saida)
        {
            return lEntrada.Serializar(Saida, new Type[0]);
        }
        public static bool Serializar(this object lEntrada, string Saida, Type[] types)
        {
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(lEntrada.GetType(), types);
                StreamWriter sw = new StreamWriter(Saida, false, System.Text.Encoding.Default);
                mySerializer.Serialize(sw, lEntrada);
                sw.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static List<Item> Deserializar(this string FullPath, Type[] types)
        {
            List<Item> lSaida = new List<Item>();
            XmlSerializer mySerializer = new XmlSerializer(lSaida.GetType(), types);
            StreamReader sr = new StreamReader(FullPath, FullPath.ReconhecerCodificacao());

            lSaida = (List<Item>)mySerializer.Deserialize(sr);
            sr.Close();
            return lSaida;
        }
    }
}