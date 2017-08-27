namespace IoC
{
	using System;

	public interface IIoCContainer
	{
		T Resolve<T>();

		object Resolve(Type type);

		void RegisterTransient<T>();

		void RegisterSingleton<T>();

		void RegisterTransient<TInterface, TImplementation>() where TImplementation : class, TInterface;

		void RegisterSingleton<TInterface, TImplementation>() where TImplementation : class, TInterface;
	}
}