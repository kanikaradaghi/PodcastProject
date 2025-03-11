using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BusinessLogic
{
    public partial class PodcastHandler
    {
        IRepository<Podcast> _repository;
        List<Podcast> Podcastlista;

        public PodcastHandler()
        {
            _repository = new Podcastrespository();
             Podcastlista = _repository.GetAll();
        }

        public List<Podcast> GetAllPodcastNames()
        {
            return _repository.GetAll();
        }

        public Podcast? GetInfoPodcast(string? name)
        {
            if (name == null) return null;

            return _repository.GetAll()
                .Where(p => p.NameAc?.ToUpper() == name.ToUpper())
                .FirstOrDefault();
        }

        public string? GetInfoPodcast(string? title, string? name)
        {
            if (name == null || title == null) return null;

            var podcast = _repository.GetAll()
                .Where(p => p.NameAc?.ToUpper() == title.ToUpper())
                .FirstOrDefault();

            var description = podcast?.Episodes
                .Where(e => e.Name?.ToUpper() == name.ToUpper())
                .FirstOrDefault()?.Description;

            if (description == null)
                return null;

            description = description.Replace("<br>", "\n\n");
            description = description.Replace("</br>", "\n\n");
            description = description.Replace("&amp;", "&");
            description = description.Replace("&nbsp;", " ");

            return RemoveHtml().Replace(description, "");
        }

        public async Task<Podcast?> HamataUrl(string url)
        {
            SyndicationFeed flode = await new RSSReaders().reader(url);
            if (flode == null)
                return null;

            List<Episode> episodes = new List<Episode>();

            foreach (SyndicationItem item in flode.Items)
            {
                episodes.Add(new()
                {
                    Name = item.Title.Text,
                    Description = item.Summary.Text
                });
            }
            return new Podcast() { Name = flode.Title.Text, Episodes = episodes };
        }

        public void SkapaPodacast(Podcast g)
        {
            Podcast podacastObj = new Podcast
            {
                Category = g.Category,
                Name = g.Name,
                NameAc = g.NameAc,
                Description = g.Description,
                Genre = g.Genre,
                Episodes = g.Episodes
            };
            _repository.Insert(podacastObj);
        }

        private SyndicationFeed Reader(object url)
        {
            throw new NotImplementedException();
        }

        public void UpdatePodcast(int index, Podcast theupdatedepisode)
        {
            GetAllPodcastNames()[index] = theupdatedepisode;
            _repository.Update(index, theupdatedepisode);
            _repository.SaveChanges();
        }

  

        public void DeletePodcast(int index)
        {
            _repository.Delete(index);
            _repository.SaveChanges();
        }

        public void UpdateName(string alias, string? kategori, string? newName)
        {
            _repository.UpdateName(alias, kategori, newName);
        }

        public void UpdatePodcastsKategori(string oldCategory, string newCategory)
        {
            _repository.UpdatePodcastsCategory(oldCategory, newCategory);
        }

        public void TaBortKategoriPodcast(string gamlaVardet)
        {
            _repository.TabortKategoriIPodcast(gamlaVardet);
        }

        [GeneratedRegex("<[^>]*>")]
        private static partial Regex RemoveHtml();
    }
}

