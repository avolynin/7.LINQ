using System;

using LINQ.Parsers;

namespace LINQ
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = "D:\\Users\\Camputer\\source\\repos\\LINQ\\src\\LINQ\\res\\geo.csv";
			Parser<City> parser = new ParserFile<City>(path);
			parser.Load();

			foreach(var item in parser._elements)
			{
				Console.WriteLine(item.Value["city"]);
			}
		}
	}
}
