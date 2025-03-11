using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Domain
{
    [XmlRoot("ArrayOfKategori")]
    public class Kategori
    {
        public string? Genre { get; set; }
    }
}
