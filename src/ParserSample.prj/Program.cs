using Mallenom.Parser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParserSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var workDirectory = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..");
			string pathGeo = workDirectory + @"\res\geo.csv";

			var parser = new Parser(new ParserCSV());
			parser.Parse(pathGeo, (list) => 
				{
					ArrayList array = new ArrayList(list);
					array[0] = long.Parse	(list[0]);
					array[7] = double.Parse	(list[7], System.Globalization.CultureInfo.InvariantCulture);
					array[8] = double.Parse	(list[8], System.Globalization.CultureInfo.InvariantCulture);
					array[9] = int.Parse	(list[9]);
					return array; 
				});

			Console.WriteLine("Значение элементов по 5 id:");
			foreach(var item in parser.Data[5])
			{
				Console.WriteLine($"{item.Key}: {item.Value}. Type value is {item.Value.GetType()}\n");
			}

			const string REGION_NAME = "Вологодская область";

			Console.WriteLine($"\nГорода региона \"{REGION_NAME}\" ");
			var region = parser.Data.Where(e => (string)e.Value["region"] == REGION_NAME);
			foreach(var item in region)
			{
				Console.WriteLine($"id({item.Key}); name({item.Value["city"]});");
			}
		}
	}
}
