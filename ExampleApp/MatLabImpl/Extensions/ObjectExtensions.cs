namespace MatLabImpl.Extensions
{
	using System;
	using System.Linq;
	using Common.ArgumentMust;
	using Common.Extensions;

	public static class ObjectExtensions
	{
		public static T ToSingleValue<T>(this object result)
		{
			ArgumentMust.NotBeNull(() => result);

			return result.Cast<Array>().OfType<T>().First();
		}

		public static T[] ToSingleDimensionalArray<T>(this object result)
		{
			ArgumentMust.NotBeNull(() => result);

			return result.Cast<T[]>();
		}

		public static T[][] ToTwoDimensionalArray<T>(this object result)
		{
			ArgumentMust.NotBeNull(() => result);

			return result.Cast<T[][]>();
		}
	}
}