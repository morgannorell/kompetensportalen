using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace kompetensportalen.classes
{
    [XmlRoot("Prov")]
    public class ReadTest
    {
        [XmlElement("Kategori")]
        public List<SublevelOne> Kategori { get; set; }
    }

    public class SublevelOne
    {
        [XmlAttribute("id")]
        public string Kategorityp { get; set; }

        [XmlElement("Fråga")]
        public List<SublevelTwo> Fråga { get; set; }
    }

    public class SublevelTwo
    {
        [XmlAttribute("id")]
        public string Frågaid { get; set; }

        [XmlElement("Text")]
        public string Text { get; set; }

        [XmlElement("SvarEtt")]
        public string SvarEtt { get; set; }

        [XmlElement("SvarTvå")]
        public string SvarTvå { get; set; }

        [XmlElement("SvarTre")]
        public string SvarTre { get; set; }

        [XmlElement("SvarFyra")]
        public string SvarFyra { get; set; }

        [XmlElement("RättSvar")]
        public string RättSvar { get; set; }

        [XmlElement("Markeratsvar")]
        public string MarkeratSvar { get; set; }
    }
}