using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Domain
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string NameAc { get; set; }
        public string Category { get; set; }
        public List<Episode> Episodes { get; set; } = new List<Episode>();

        
    }
}