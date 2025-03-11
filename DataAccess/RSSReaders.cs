using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DataAccess;

namespace DataAccess
{
    public class RSSReaders
    {
        public RSSReaders()
        {
        }

        public async Task<SyndicationFeed?> reader(string url)
        {
            try
            {
                using XmlReader xmlLasare = XmlReader.Create(url);
                return await Task.Run(() => SyndicationFeed.Load(xmlLasare));
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
