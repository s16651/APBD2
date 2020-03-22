using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace APBD2.Models
{
	public class University
	{
		public University()
		{
			Students = new HashSet<Student>();
			CreationDate = DateTime.Now.ToString("yyyy-mm-dd");
			ActiveStudies = new List<ActiveStudies>();
		}
	
		[XmlAttribute]
		public string Author { get; set; }
		[JsonPropertyName("CreatedAt")]
		[XmlAttribute(AttributeName = "CreatedAt")]
		public string CreationDate { get; set; }
		public HashSet<Student> Students { get; set; }
		public List<ActiveStudies> ActiveStudies { get; set; }

	}
}
