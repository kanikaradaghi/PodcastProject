using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Domain;

namespace DataAccess
{
    public class Serializer<T>
    {
        private string fileName;

        public string FileName
        {
            set
            {
                fileName = value;
            }
        }

        public Serializer(string filNamn)
        {
            FileName = filNamn + ".xml";
        }

        public void Serialize(List<T> list)
        {
            List<T> existingData = Deserialize<T>();
            existingData.AddRange(list);

            XmlSerializer xmlseri = new XmlSerializer(typeof(List<T>));
            using (FileStream filOut = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlseri.Serialize(filOut, list);
            }
        }

        public List<T> Deserialize<T>()
        {
            List<T> listan = new List<T>(); 
            XmlSerializer xmlseri = new XmlSerializer(typeof(List<T>));
            try
            {
                if (File.Exists(fileName))
                {
                    using (FileStream filIn = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        listan = (List<T>)xmlseri.Deserialize(filIn);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Undantag vid deserialisering: " + ex.Message);
            }
            return listan; 
        }
    }
}
