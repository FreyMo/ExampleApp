namespace ServiceLocation
{
	using Ninject;

	public class ServiceLocator
	{
		private readonly IKernel _kernel;

		public static ServiceLocator Instance { get; private set; }

		public T Get<T>()
		{
			return Instance._kernel.Get<T>();
		}

		private ServiceLocator(IKernel kernel)
		{
			_kernel = kernel;
		}

		internal static void CreateInstance(IKernel kernel)
		{
			Instance = new ServiceLocator(kernel);
		}
	}
}