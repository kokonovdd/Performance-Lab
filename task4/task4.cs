using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class task4
{
	static int Parser(string[] args)
	{
		if (args.Length != 1)
		{
			Console.WriteLine("Неверное количество аргументов. Должен быть указан 1 файл.");
			return 1;
		}

		string filePath = args[0];
		List<int> numbers = new List<int>();

		try
		{
			using (StreamReader reader = new StreamReader(filePath))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					int number;
					if (int.TryParse(line.Trim(), out number))
						numbers.Add(number);
				}
			}
		}
		catch (IOException e)
		{
			Console.WriteLine($"Ошибка открытия файла: {filePath}\n{e.Message}");
			return 1;
		}

		// Сортируем список чисел
		numbers.Sort();

		// Находим медиану
		int median = numbers[numbers.Count / 2];

		// Суммируем необходимое количество движений
		int totalMoves = numbers.Sum(num =>
		{
			if (num > median)
				return num - median;
			else if (num < median)
				return median - num;
			return 0;
		});

		Console.WriteLine($"Минимальное количество ходов: {totalMoves}");
		return 0;
	}

	static void Main(string[] args)
	{
		int exitCode = Parser(args);
		Environment.Exit(exitCode);
	}
}