namespace MatLabImpl
{
	using System;
	using System.Threading.Tasks;
	using Common.Dispose;
	using Extensions;
	using MathLibNative;
	using MatLab;

	internal class MathLibNativeWrapper : DisposableBase, IMathLibNativeWrapper
	{
		private readonly MathLib _native = new MathLib();

		public Task<T> AddAsync<T>(T first, T second) where T : struct, IComparable, IFormattable, IConvertible
		{
			return Task.Run(() => _native.Add(first, second).ToSingleValue<T>());
		}

		public Task<T> SubstractAsync<T>(T first, T second) where T : struct, IComparable, IFormattable, IConvertible
		{
			return Task.Run(() => _native.Substract(first, second).ToSingleValue<T>());
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