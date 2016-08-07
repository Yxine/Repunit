using System;
using System.Reflection;
using YxinityGroup.Math;

/// <summary>Главная программа</summary>
public class Program
{

	/// <summary>Точка входа</summary>
	/// <param name="args">Аргументы командной строки</param>
	private static void Main(string[] args)
	{

		Console.Clear();
		Console.Title = "Repunit Cloud";
		Console.CursorVisible = false;
		Console.WriteLine();
		Console.WriteLine(" *");
		Console.WriteLine($" * Repunit Cloud version {Assembly.GetEntryAssembly().GetName().Version}");
		Console.WriteLine(" * http://computerraru.ru/software/repunit");
		Console.WriteLine(" * Larin Alexsandr");
		Console.WriteLine(" *");
		Console.WriteLine();
		Console.ForegroundColor = ConsoleColor.White;

		if (!args.Length.Equals(1))
		{
			Console.WriteLine("   Ошибочка...");
			Console.WriteLine("   Укажите первым параметром требуемый номер репюнита, например:");
			Console.WriteLine();
			Console.WriteLine("   > repunit.exe 400");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("   Press a key to exit...");
			Console.ReadKey();
			return;
		}

		var i = 0;
		int.TryParse(args[0], out i);

		if (i <= 0)
		{
			Console.WriteLine("   Ошибочка...");
			Console.WriteLine("   Номер репюнита должен быть натуральным числом до 1 000 000 000, например:");
			Console.WriteLine();
			Console.WriteLine("   > repunit.exe 400");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("   Press a key to exit...");
			Console.ReadKey();
			return;
		}

		if (i > 999999999)
		{
			Console.WriteLine("   Ошибочка...");
			Console.WriteLine("   Номер репюнита должен быть натуральным числом меньше 1 000 000 000, например:");
			Console.WriteLine();
			Console.WriteLine("   > repunit.exe 400");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("   Press a key to exit...");
			Console.ReadKey();
			return;
		}

		var repunit = new Repunit.RepunitStruct(i);

		Console.WriteLine("   Начнем наши изыскания над репюнитом!");
		Console.WriteLine();
		Console.WriteLine($"   R(P) = R({repunit.P}) = (10 ^ {repunit.P} - 1) / 9 = {FX.ShowCompactNumber(repunit.Repunit)}");
		Console.WriteLine();
		Console.WriteLine($"   Ищем делители по формуле D = 2 * K * P + 1 = {2 * repunit.P} * P + 1, где");
		Console.WriteLine($"   Kmin = {repunit.Kmin}");
		Console.WriteLine($"   Kmax = {FX.ShowCompactNumber(repunit.Kmax)}");
		Console.WriteLine();

		int top = Console.CursorTop;
		i = 0;

		while (repunit.Kcur <= repunit.Kmax)
		{
			i++;
			if ((i % Settings.OutputIterval).Equals(0))
			{
				Console.SetCursorPosition(0, top);
				Console.WriteLine($"   Проверяем Kcur = {repunit.Kcur}...");
			}
			if ((i % Settings.SaveIterval).Equals(0))
			{
				// Save
			}
			if (Repunit.IsFactor(repunit))
			{
				Console.WriteLine($"   Делитель найден! D = {repunit.DividerCur}, Kcur = {repunit.Kcur}");
				break;
			}
			repunit = Repunit.NextK(repunit);
		}

		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine();
		Console.WriteLine("   Press a key to exit...");
		Console.ReadKey();

	}

}
