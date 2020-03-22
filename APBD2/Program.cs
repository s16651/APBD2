using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;
using APBD2.Models;

namespace APBD2
{
	class Program
	{
		static void ListOfActiveStudies(University university, List<String> Studieslist)
		{
			var list = from z in Studieslist
					   group z by z into k
					   let count = k.Count()
					   orderby count ascending
					   select new { Value = k.Key, Count = count };
			foreach (var studi in list)
			{
				university.ActiveStudies.Add(new ActiveStudies { Name = studi.Value, NrOfStudents = studi.Count.ToString() });
			}
		}
		static void Main(string[] args)
		{
			var inputPath = args.Length > 0 ? args[0] : @"Files\data.csv";
			var outputPath = args.Length > 1 ? args[1] : @"Files\result";
			var outputType = args.Length > 2 ? args[2] : "xml";
			Console.WriteLine($"{inputPath}\n{outputPath}\n{ outputType}");
			try
			{
				if (!File.Exists(inputPath)) { throw new FileNotFoundException("Error", inputPath.Split("\\")[^1]); }
				var university = new University { Author = "Lewandowski Jakub" };
				var studieslist = new List<String>();
				foreach (var line in File.ReadAllLines(inputPath))
				{
					var split = line.Split(",");
					if (split.Length < 9)
					{
						File.AppendAllText(@"Files\Log.txt", $"{DateTime.UtcNow} Error line has not enough columns{line} \n");
						continue;
					}
					studieslist.Add(split[2]);
					var stud = new Student
					{
						IndexNumber = split[4],
						Name = (split[0]),
						Lastname = (split[1]),
						BirthDate = split[5],
						Email = split[6],
						MName = split[7],
						FName = split[8],
						Studies = new Study { Name = (split[2]), Mode = (split[3]) }
					};
					university.Students.Add(stud);
				}
				ListOfActiveStudies(university, studieslist);
				using var writer = new FileStream($"{outputPath}.{outputType}", FileMode.Create);
				var serializer = new XmlSerializer(typeof(University));
				serializer.Serialize(writer, university);

				var jsonString = JsonSerializer.Serialize(university, typeof(University));
				File.WriteAllText($"{outputPath}.json", jsonString);

			}
			catch (FileNotFoundException e)
			{
				File.AppendAllText(@"Files\Log.txt", $"{DateTime.UtcNow} {e.Message} File not found ({e.FileName})\n");

			}
		}

	}
}