namespace MatLab
{
	using System;
	using System.Threading.Tasks;

	public interface IMathLibNativeWrapper : INativeWrapperBase
	{
		Task<T> AddAsync<T>(T first, T second) where T : struct, IComparable, IFormattable, IConvertible;

		Task<T> SubstractAsync<T>(T first, T second) where T : struct, IComparable, IFormattable, IConvertible;
	}
}