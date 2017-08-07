namespace MatLab
{
	using System;

	public interface IMathLibNativeWrapper : INativeWrapperBase
	{
		T Add<T>(T first, T second) where T : struct, IComparable, IFormattable, IConvertible;

		T Substract<T>(T first, T second) where T : struct, IComparable, IFormattable, IConvertible;
	}
}