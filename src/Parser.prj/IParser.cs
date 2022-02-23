using System;
using System.Collections;
using System.Collections.Generic;

namespace Mallenom.Parser
{
	/// <summary>Обеспечивает механизм парсинга.</summary>
	public interface IParser
	{
		/// <summary>Автоматизированный сбор и структурирование информации.</summary>
		/// <param name="pathFile">Путь к файлу.</param>
		/// <param name="func">Делегат для конвертации элементов в соответсвующие типы.</param>
		/// <returns>Структурированая информация из файла с соответствующими типами.</returns>
		public Dictionary<long, Dictionary<string, object>> Parse(string pathFile, Func<List<string>, ArrayList> func);
	}
}
