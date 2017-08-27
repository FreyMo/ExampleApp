namespace IoCImpl
{
	using System;
	using IoC;
	using Ninject;

	public class NinjectAdapter : IIoCContainer
	{
		private readonly IKernel _kernel;

		public NinjectAdapter(IKernel kernel)
		{
			_kernel = kernel;
		}

		public T Resolve<T>()
		{
			return _kernel.Get<T>();
		}

		public object Resolve(Type type)
		{
			return _kernel.Get(type);
		}

		public void RegisterTransient<T>()
		{
			_kernel.Bind<T>().ToSelf().InTransientScope();
		}

		public void RegisterSingleton<T>()
		{
			_kernel.Bind<T>().ToSelf().InSingletonScope();
		}

		public void RegisterTransient<TInterface, TImplementation>() where TImplementation : class, TInterface
		{
			_kernel.Bind<TInterface>().To<TImplementation>().InTransientScope();
		}

		public void RegisterSingleton<TInterface, TImplementation>() where TImplementation : class, TInterface
		{
			_kernel.Bind<TInterface>().To<TImplementation>().InSingletonScope();
		}
	}
}