#if DEBUG
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
using System.Numerics;
using System.IO;

namespace YxinityGroup.Math
{

	/// <summary>Класс для работы с repunit</summary>
	public static class Repunit
	{

		/// <summary></summary>
		public struct RepunitStruct
		{

			/// <summary></summary>
			public int P;

			/// <summary></summary>
			public BigInteger Repunit;

			/// <summary></summary>
			public BigInteger Kmin;

			/// <summary></summary>
			public BigInteger Kmax;

			/// <summary></summary>
			public BigInteger Kcur;

			/// <summary></summary>
			public int DividerMult;

			/// <summary></summary>
			public BigInteger DividerCur;

			/// <summary>Конструктор</summary>
			/// <param name="p"></param>
			public RepunitStruct(int p)
			{
				P = p;
				Repunit = Init(p);
				Kmin = 1;
				Kmax = SqRtN(Repunit);
				Kcur = Kmin;
				DividerMult = 2 * p;
				DividerCur = DividerMult + 1;
			}

		}

		/// <summary></summary>
		/// <param name="repunit"></param>
		/// <returns></returns>
		public static bool IsFactor(RepunitStruct repunit)
		{
			BigInteger reminder;
			BigInteger.DivRem(repunit.Repunit, repunit.DividerCur, out reminder);
			return reminder == 0;
		}

		/// <summary></summary>
		/// <param name="repunit"></param>
		/// <returns></returns>
		public static BigInteger Init(int repunit)
		{
			var bi = new BigInteger(10);
			bi = BigInteger.Pow(bi, repunit);
			bi = BigInteger.Subtract(bi, BigInteger.One);
			bi = BigInteger.Divide(bi, new BigInteger(9));
			return bi;
		}

		/// <summary></summary>
		/// <param name="p"></param>
		/// <param name="repunit"></param>
		/// <returns></returns>
		public static bool OpenRepunit(int p, out RepunitStruct repunit)
		{
			repunit = new RepunitStruct();
			return false;
		}

		/// <summary></summary>
		/// <param name="repunit"></param>
		/// <returns></returns>
		public static bool SaveRepunit(RepunitStruct repunit)
		{
			try
			{
				File.AppendAllText($"{repunit.P}.repunit", repunit.Kcur.ToString());
				return true;
			}
			catch
			{
			}
			return false;
		}

		/// <summary>Извлечение квадратного корня методом Ньютона</summary>
		/// <param name="N">Число из которого извлекаем квадратный корень</param>
		/// <returns></returns>
		public static BigInteger SqRtN(BigInteger N)
		{
			if (N < 4) return 1;
			if (N < 9) return 2;
			if (N < 16) return 3;
			// Using Newton Raphson method we calculate the square root (N/g + g)/2
			BigInteger rootN = N;
			// There is a bug in finding bit length hence we start with 1 not 0
			int bitLength = 1;
			while (rootN / 2 != 0)
			{
				rootN /= 2;
				bitLength++;
			}
			bitLength = (bitLength + 1) / 2;
			rootN = N >> bitLength;
			BigInteger lastRoot = BigInteger.Zero;
			do
			{
				lastRoot = rootN;
				rootN = (BigInteger.Divide(N, rootN) + rootN) >> 1;
			}
			while (!((rootN ^ lastRoot).ToString() == "0"));
			return rootN;
		}

		/// <summary></summary>
		/// <param name="repunit"></param>
		/// <returns></returns>
		public static RepunitStruct NextK(RepunitStruct repunit)
		{
			repunit.Kcur = repunit.Kcur + 1;
			repunit.DividerCur = repunit.Kcur * repunit.DividerMult + 1;
			return repunit;
		}

	}

	#if DEBUG

	/// <summary>Класс с юнит-тестами</summary>
	[TestClass()]
	public class RepunitTestClass
	{

		/// <summary>Метод с юнит-тестами</summary>
		[TestMethod()]
		public void RepunitTestMethod()
		{
			// nop
		}

	}

	#endif

}
