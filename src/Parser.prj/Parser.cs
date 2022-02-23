using System;
using System.Collections;
using System.Collections.Generic;

namespace Mallenom.Parser
{
	/// <summary>
	/// Основной класс парсинга предоставляющий доступ к 
	/// различным реализациям интерфейса IParser.
	/// </summary>
	public class Parser : IEnumerable
	{
		/// <summary>Стратегия парсига для определенных форматов.</summary>
		private IParser _parserStrategy;

		/// <summary>Хранение структурированной информации.</summary>
		public Dictionary<long, Dictionary<string, object>> Data { get; private set; }

		/// <summary>Конструктор класса Parser.</summary>
		/// <param name="parserStrategy">Стратегия парсига для определенных форматов.</param>
		public Parser(IParser parserStrategy)
		{
			_parserStrategy = parserStrategy;
		}

		/// <summary>Автоматизированный сбор и структурирование информации определенной стратегией.</summary>
		/// <param name="pathFile">Путь к файлу.</param>
		/// <param name="func">Делегат для конвертации элементов в соответсвующие типы.</param>
		public void Parse(string path, Func<List<string>, ArrayList> func)
		{
			Data = _parserStrategy.Parse(path, func);
		}

		public IEnumerator GetEnumerator()
		{
			return Data.GetEnumerator();
		}
	}
}
