namespace IoC
{
	using System;

	public class ServiceLocator
	{
		private readonly IIoCContainer _container;

		public static ServiceLocator Instance { get; private set; }

		public T Resolve<T>()
		{
			return Instance._container.Resolve<T>();
		}

		//public object Get(Type type)
		//{
		//	return Instance._container.Resolve(type);
		//}
		
		private ServiceLocator(IIoCContainer container)
		{
			_container = container;
		}

		internal static void CreateInstance(IIoCContainer container)
		{
			Instance = new ServiceLocator(container);
		}
	}
}