using System.Xml.Serialization;

namespace APBD2.Models
{
    public class ActiveStudies
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string NrOfStudents { get; set; }
    }
}
