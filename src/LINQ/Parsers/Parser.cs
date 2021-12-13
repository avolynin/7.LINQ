using System.Collections;
using System.Collections.Generic;

namespace LINQ.Parsers
{
	public abstract class Parser<T> where T : class
	{
		//protected private Dictionary<int, Dictionary<string, string>> _elements;
		public Dictionary<int, Dictionary<string, string>> _elements;

		public List<string> Tags { get; set; } = new List<string>();
		public string Path { get; set; }
		public string Content { get; set; }

		public Parser(string path)
		{
			Path = path;
		}

		abstract public void Load();
		abstract public List<T> Parse(string attribute);
	}
}
