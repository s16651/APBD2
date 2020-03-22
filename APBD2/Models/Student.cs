using System.Xml.Serialization;
namespace APBD2.Models
{
    public class Student
{
    [XmlAttribute]
    public string IndexNumber { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string BirthDate { get; set; }
    public string Email { get; set; }
    public string FName { get; set; }
    public string MName { get; set; }
    public Study Studies { get; set; }

}
}