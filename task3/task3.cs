using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class task3
{
	public static void Main(string[] args)
	{
		if (args.Length != 3)
		{
			Console.WriteLine("Ошибка: Необходимо передать 3 параметра: paths to values.json, tests.json, report.json");
			Environment.Exit(1);
		}

		string valuesFilePath = args[0]; // Путь к файлу values.json
		string testsFilePath = args[1]; // Путь к файлу tests.json
		string reportFilePath = args[2]; // Путь к выходному файлу report.json

		List<ValueItem> valuesList = ReadJson<List<ValueItem>>(valuesFilePath);
		Dictionary<string, object> testsDict = ReadJson<Dictionary<string, object>>(testsFilePath);

		FillValues(testsDict, valuesList);

		WriteJson(reportFilePath, testsDict);

		Console.WriteLine("Файл report.json был успешно создан.");
	}

	private static T ReadJson<T>(string filePath)
	{
		string content = File.ReadAllText(filePath);
		return JsonConvert.DeserializeObject<T>(content);
	}

	private static void WriteJson(string filePath, object obj)
	{
		string output = JsonConvert.SerializeObject(obj, Formatting.Indented);
		File.WriteAllText(filePath, output);
	}

	private static void FillValues(Dictionary<string, object> tests, List<ValueItem> values)
	{
		foreach (var entry in tests)
		{
			if (entry.Value is Dictionary<string, object>)
			{
				FillValues(entry.Value as Dictionary<string, object>, values);
			}
			else if (entry.Key == "id")
			{
				int id = int.Parse((string)entry.Value);
				ValueItem matchingValue = values.Find(v => v.Id == id);
				if (matchingValue != null)
				{
					tests["value"] = matchingValue.Value;
				}
			}
		}
	}

	public class ValueItem
	{
		public int Id { get; set; }
		public string Value { get; set; }
	}
}