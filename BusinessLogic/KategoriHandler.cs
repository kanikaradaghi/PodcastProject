using Domain;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic
{
    [XmlRoot("ArrayOfKategori")]
    public class KategoriHandler
    {
        IRepository<Kategori> kategoriRepository;
        List<Kategori> kategorilista;
        public KategoriHandler()
        {
            kategoriRepository = new Kategorirespository();
            kategorilista = kategoriRepository.GetAll();
        }

        public void SkapaKategori(string genre)
        {
            Kategori kategoriObjekt = new Kategori
            {
                Genre = genre
            };
            kategoriRepository.Insert(kategoriObjekt);
        }

        public void UpdateraKategori(int index, Kategori theNewObject)
        {
            if (index >= 0 && index < HamtaKategoriLista().Count)
            {
                HamtaKategoriLista()[index] = theNewObject;
                kategoriRepository.Update(index, theNewObject);
                kategoriRepository.SaveChanges();
            }
        }

        public void TaBortKategori(int index)
        {
            if(index >= 0 && index< HamtaKategoriLista().Count)
            {
                kategoriRepository.Delete(index);
                kategoriRepository.SaveChanges();
            };
        }

        public List<Kategori> HamtaKategoriLista()
        {
            return kategoriRepository.GetAll();  
        }

        public bool KategoriExists(string name)
        {
            List<Kategori> befintligaKategorier = HamtaKategoriLista();
            bool exists = befintligaKategorier.Any(kategori => kategori.Genre == name);
            return exists;
        }
    }
}
