namespace ServiceLocation.ViewModelLocator
{
	using System;
	using Common.ArgumentMust;
	using Ninject;

	public class ViewModelLocator : IViewModelLocator
	{
		private readonly IKernel _kernel;

		public ViewModelLocator(IKernel kernel)
		{
			ArgumentMust.NotBeNull(() => kernel);

			_kernel = kernel;
		}

		public T Get<T>() => _kernel.Get<T>();

		public object Get(Type type) => _kernel.Get(type);
	}
}
