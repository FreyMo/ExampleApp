namespace IoC
{
	public class ServiceLocator
	{
		private readonly IIoCContainer _container;

		public static ServiceLocator Instance { get; private set; }

		public T Resolve<T>()
		{
			return Instance._container.Resolve<T>();
		}

		private ServiceLocator(IIoCContainer container)
		{
			_container = container;
		}

		private static void CreateInstance(IIoCContainer container)
		{
			Instance = new ServiceLocator(container);
		}
	}
}