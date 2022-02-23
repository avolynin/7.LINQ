using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mallenom.Parser
{
	/// <summary>Реализует механизм парсинга от IParser.</summary>
	public class ParserCSV : IParser
	{
		public Dictionary<long, Dictionary<string, object>> Parse(string path, Func<List<string>, ArrayList> func)
		{
			var dictionary = new Dictionary<long, Dictionary<string, object>>();
			using var reader = File.OpenText(path);

			// Первая строка - ключевые слова
			List<string> keywords = GetElementsFromLine(reader);

			while(!reader.EndOfStream)
			{
				var row = GetElementsFromLine(reader);

				ArrayList array = func(row);	// Инструкция преобразования типов
				long id = (long)array[0];		// Первый элемент в строке - id 

				var dictElements = new Dictionary<string, object>();
				for(int i = 1; i < keywords.Count; i++)
				{
					dictElements.Add(keywords[i], array[i]);
				}

				dictionary.Add(id, dictElements);
			}
			
			return dictionary;
		}

		/// <summary>Форматирование данных из файла формата CSV.</summary>
		/// <param name="reader">Потоковый читатель из файла.</param>
		/// <returns>Список элементов из строки с типом данных string.</returns>
		private List<string> GetElementsFromLine(StreamReader reader)
		{
			return reader.ReadLine()				// Чтение строки с ключами
				.Split(";")							// Создание массива строк с ключами разделенными знаком ";"
				.Select(p => p.Replace("\"", ""))	// Удаление двойных кавычек
				.ToList();
		}
	}
}
