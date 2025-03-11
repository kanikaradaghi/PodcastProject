using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Domain;

namespace DataAccess
{
    [XmlRoot("ArrayOfKategori")]
    public class Kategorirespository : IRepository<Kategori>
    {
        Serializer<Kategori> kategoriSerializer;
        List<Kategori> ListAvKategori;

        public Kategorirespository()
        {
            ListAvKategori = new List<Kategori>();
            kategoriSerializer = new Serializer<Kategori>(nameof(ListAvKategori));
            ListAvKategori = GetAll();
        }

        public List<Kategori> GetAll()
        {
            List<Kategori> registreradePodcast = new List<Kategori>();
            try
            {
                registreradePodcast = kategoriSerializer.Deserialize<Kategori>();
            }
            catch (Exception)
            {
                Console.Write("shjwd");
            }
            return registreradePodcast;
        }

        public void Insert(Kategori theObject)
        {
            ListAvKategori.Add(theObject);
            SaveChanges();
        }

        public void Update(int index, Kategori theNewObject)
        {
            if (index >= 0)
            {
                ListAvKategori[index] = theNewObject;
            }
            SaveChanges();
        }
        public void Delete(int index)
        {
             ListAvKategori.RemoveAt(index);
             SaveChanges(); 
        }

        public void SaveChanges()
        {
            kategoriSerializer.Serialize(ListAvKategori);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void UpdateName(string name, string? kategori, string? newName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePodcastsCategory(string oldCategory, string newCategory)
        {
            throw new NotImplementedException();
        }

        public void TabortKategoriIPodcast(string gamlaVärdet)
        {
            throw new NotImplementedException();
        }
    }
}
