using System;

class task1
{
	static string CircularArrayPath(int n, int m)
	{
		var path = new int[n];
		int currentIndex = 0;

		// Заполняем путь последовательностью посещённых позиций
		for (int i = 0; i < n; i++)
		{
			path[i] = (currentIndex % n) + 1;     // Добавляем индекс позиции (+1 для отображения с 1)
			currentIndex = (currentIndex + m - 1) % n;  // Обновляем текущий индекс
		}

		// Преобразуем целочисленные позиции в строку
		return string.Join("", path);              // Объединяем цифры в одну строку
	}

	static void Main(string[] args)
	{
		if (args.Length != 2)
		{
			Console.WriteLine("Использование: task1 <n> <m>");
			Environment.Exit(1);
		}

		int n = Convert.ToInt32(args[0]);
		int m = Convert.ToInt32(args[1]);

		string result = CircularArrayPath(n, m);
		Console.WriteLine(result);
	}
}