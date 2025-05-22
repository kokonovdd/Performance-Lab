using System;
using System.IO;

namespace PointPositionCalculator
{
	class task2
	{
		static void Main(string[] args)
		{
			int result = Creat(args);
			Environment.Exit(result);
		}

		static int Creat(string[] args)
		{
			if (args.Length != 2)
			{
				Console.WriteLine("Неверное количество аргументов. Должны быть указаны 2 файла.");
				return 1;
			}

			try
			{
				using StreamReader circleFile = new StreamReader(args[0]);
				using StreamReader pointsFile = new StreamReader(args[1]);

				// Чтение координат центра окружности и радиуса из первого файла
				double centerX, centerY, radius;
				string line = circleFile.ReadLine().Trim();
				string[] values = line.Split(' ');
				centerX = double.Parse(values[0]);
				centerY = double.Parse(values[1]);
				radius = double.Parse(values[2]);

				// Чтение точек из второго файла и проверка их положения относительно окружности
				string pointLine;
				while ((pointLine = pointsFile.ReadLine()) != null)
				{
					string[] pointValues = pointLine.Trim().Split(' ');
					double x = double.Parse(pointValues[0]);
					double y = double.Parse(pointValues[1]);

					int position = CalculatePointPosition(x, y, centerX, centerY, radius);
					Console.WriteLine(position);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка обработки файлов: {ex.Message}");
				return 1;
			}

			return 0;
		}

		static int CalculatePointPosition(double x, double y, double centerX, double centerY, double radius)
		{
			double distance = Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2);
			radius = Math.Pow(radius, 2);

			if (distance == radius)
			{
				return 0; // Точка лежит на окружности
			}
			else if (distance < radius)
			{
				return 1; // Точка находится внутри круга
			}
			else
			{
				return 2; // Точка вне круга
			}
		}
	}
}