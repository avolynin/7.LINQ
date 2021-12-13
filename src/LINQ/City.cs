using System.Collections.Generic;

namespace LINQ
{
	class City
	{
		/// <summary>Keys of resources.</summary>
		const string NAME = "Name";
		const string COUNTRY = "Country";
		const string REGION = "Region";

		public Dictionary<string, Dictionary<string, string>> Names;

		public City(int id, Dictionary<string, Dictionary<string, string>> names, (float lat, float lng) coords, ulong population)
		{
			Id = id;
			Names = names;
			Coords = coords;
			Population = population;
			//Dictionary<string, string> ruNames = new Dictionary<string, string>
			//{
			//	{NAME, ""},
			//	{COUNTRY, ""},
			//	{PROVINCE, ""}
			//};
			//Dictionary<string, string> engNames = new Dictionary<string, string>
			//{
			//	{NAME, ""},
			//	{COUNTRY, ""},
			//	{PROVINCE, ""}
			//};
			//Names = new Dictionary<string, Dictionary<string, string>>
			//{
			//	{"ru", ruNames},
			//	{"eng", engNames}
			//};
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public string Region { get; set; }
		public (float lat, float lng) Coords { get; set; }
		public ulong Population { get; set; }
	}
}
