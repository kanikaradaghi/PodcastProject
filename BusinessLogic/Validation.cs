using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows;
using DataAccess;

namespace BusinessLogic
{
    public class Validation
    {
        private Kategorirespository kategoriRespository;
        private Podcastrespository podcastresRespository;

        public Validation() { 
        kategoriRespository = new Kategorirespository();
        podcastresRespository = new Podcastrespository();
        }

        //Säkerställer att URL-adress är giltigt 
        public bool IsUrlValid(string url)
        {
            Uri uriResult; 
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) 
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }

        //Säkerställer att namnet som man ger ett viss podcast-flöde är unikt
        public bool IsPodNameTaken(string name)
        {
            foreach (var podName in podcastresRespository.GetAll())
            {
                if (podName.Name == name)
                {
                    return true;
                }
            }
            return false;
        }


        //Säkerställer att kategorin som man skapat/ändrat namn till är unik
        public bool IsCategoryTaken(string name)
        {
            foreach (var category in kategoriRespository.GetAll()) 
            {
                if (category.Genre == name)
                {
                    return true;
                }
            }
            return false;
        }


        //Säkerställer att internetanslutning finns vid hämtning av ny RSS
        //public bool IsInternetAviable() 
        //{
        //bool result = NetworkInterface.GetIsNetworkAvailable();
        //    return result;
        //}
    }
}
