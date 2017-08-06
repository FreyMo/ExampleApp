namespace MatLabImpl.Extensions
{
	using System;
	using Common.ArgumentMust;
	using MathWorks.MATLAB.NET.Arrays;

	internal static class MatLabArrayExtensions
	{
		internal static MWNumericArray ToNumericArray<T>(this T numericValue) where T : struct, IComparable, IFormattable, IConvertible
		{
			return new MWNumericArray(new[] { numericValue });
		}

		internal static MWNumericArray ToNumericArray<T>(this T[] numericArray) where T : struct, IComparable, IFormattable, IConvertible
		{
			ArgumentMust.NotBeNull(() => numericArray);

			return new MWNumericArray(numericArray);
		}

		internal static MWNumericArray ToNumericArray<T>(this T[][] numericArray) where T : struct, IComparable, IFormattable, IConvertible
		{
			ArgumentMust.NotBeNull(() => numericArray);

			return new MWNumericArray(numericArray);
		}
	}
}