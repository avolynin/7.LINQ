using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace LINQ.Parsers
{
	class ParserFile<T> : Parser<T> where T: class
	{
		public ParserFile(string pathFile) : base(pathFile)
		{
			
		}

		public override void Load()
		{
			//TODO: Разварить эту кашу(рабочую!)
			using FileStream fileStream = File.OpenRead(Path);
			byte[] buffer = new byte[fileStream.Length];
			fileStream.Read(buffer);

			Content = Encoding.Default.GetString(buffer);
			var tags = Content.Split("\n")[0].Split(";");
			for(int i = 0; i < tags.Length; i++)
			{
				tags[i] = Regex.Replace(tags[i], "\"", "");
			}
			Tags.AddRange(tags);
			var countElements = Content.Split("\n").Length - 1;
			_elements = new Dictionary<int, Dictionary<string, string>>(countElements);
			for(int i = 1; i < 20; i++)
			{
				var lineOfElements = Content.Split("\n")[i];
				var elements = new Dictionary<string, string>(Tags.Count - 1);
				var tmp = lineOfElements.Split(";")[0];
				tmp = Regex.Replace(tmp, "\"", "");
				var id = Convert.ToInt32(tmp);
				Console.WriteLine(id);
				for(int j = 1; j < Tags.Count; j++)
				{
					tmp = lineOfElements.Split(";")[j];
					tmp = Regex.Replace(tmp, "\"", "");
					elements.Add(Tags[j], tmp);
				}

				_elements.Add(id, elements);
			}
		}

		public override List<T> Parse(string attribute)
		{
			//_elements = new List<T>();
			//_elements.Add(new T())
			return new List<T>();
		}
	}
}
