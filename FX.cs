using System.Numerics;

/// <summary></summary>
// ReSharper disable once CheckNamespace
public static class FX
{

	/// <summary>Отображение числа в компактном виде</summary>
	/// <param name="number">Число в строковом представлении</param>
	/// <returns>Компактный вид числа</returns>
	public static string ShowCompactNumber(string number)
	{
		var l = number.Length;
		return l < 11 ? $"{number} (длина {l} байт)" : $"{number.Substring(0, 5)}...{number.Substring(l - 5)} (длина {l} байт)";
	}

	/// <summary>Отображение числа в компактном виде</summary>
	/// <param name="number">Число в BigInteger представлении</param>
	/// <returns>Компактный вид числа</returns>
	public static string ShowCompactNumber(BigInteger number)
	{
		return ShowCompactNumber(number.ToString());
	}

}
