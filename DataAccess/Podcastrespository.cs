using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Domain;

namespace DataAccess
{
    public class Podcastrespository : IRepository<Podcast>
    {
        Serializer<Podcast> podcastSerializer;
        List<Podcast> ListAvPodcast;

        public Podcastrespository()
        {
            ListAvPodcast = new List<Podcast>();
            podcastSerializer = new Serializer<Podcast>(nameof(ListAvPodcast));
            ListAvPodcast = GetAll();
        }

        public List<Podcast> GetAll()
        {
            List<Podcast> registreradePodcast = new List<Podcast>();
            try
            {
                registreradePodcast = podcastSerializer.Deserialize<Podcast>();
            }
            catch (Exception)
            {   
            }
            return registreradePodcast;
        }

        public void Insert(Podcast theObject)
        {
            ListAvPodcast.Add(theObject);
            SaveChanges();
        }

        public void Update(int index, Podcast theNewObject)
        {
            if (index >= 0)
            {
                ListAvPodcast[index] = theNewObject;
            }
            SaveChanges();
        }
        public void Delete(int index)
        {
            ListAvPodcast.RemoveAt(index);
            SaveChanges();
        }

        public void UpdateName(string namn, string? kategori, string? nyttNamn)
        {
            var pod = ListAvPodcast.FirstOrDefault(p => p.Name.ToUpper() == namn.ToUpper());
            if (pod == null)
                return;
            if (!string.IsNullOrEmpty(nyttNamn))
                pod.NameAc = nyttNamn;

            if (!string.IsNullOrEmpty(kategori))
                pod.Category = kategori;

            SaveChanges();
        }

        public void UpdatePodcastsCategory(string oldCategory, string newCategory)
        {
            var podcastsToUpdate = ListAvPodcast.Where(p => p.Category == oldCategory).ToList();
            foreach (var podcast in podcastsToUpdate)
            {
                podcast.Category = newCategory;
            }
            SaveChanges();
        }

        public void TabortKategoriIPodcast(string gamlaVardet)
        {
            var kategoriAttTaBort = ListAvPodcast.Where(p => p.Category == gamlaVardet).ToList();
            foreach (var podcast in kategoriAttTaBort)
            {
                podcast.Category = "Ingen kategori vald";
            }
            SaveChanges();
        }
        public void SaveChanges()
        {
            try
            {
                podcastSerializer.Serialize(ListAvPodcast);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid sparning av ändringar: " + ex.Message);

            }
        }

        public void Reset()
        {
            ListAvPodcast = new List<Podcast>();
            SaveChanges();
        }

    }
}
