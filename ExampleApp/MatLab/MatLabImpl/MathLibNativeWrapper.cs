namespace MatLabImpl
{
	using System;
	using Common.Dispose;
	using Extensions;
	using MathLibNative;
	using MatLab;

	internal class MathLibNativeWrapper : DisposableBase, IMathLibNativeWrapper
	{
		private readonly MathLib _native = new MathLib();

		public T Add<T>(T first, T second) where T : struct, IComparable, IFormattable, IConvertible
		{
			return _native.Add(first, second).ToSingleValue<T>();
		}

		public T Substract<T>(T first, T second) where T : struct, IComparable, IFormattable, IConvertible
		{
			return _native.Substract(first, second).ToSingleValue<T>();
		}

		protected override void Dispose(bool disposing)
		{
			if (!Disposed)
			{
				_native.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}