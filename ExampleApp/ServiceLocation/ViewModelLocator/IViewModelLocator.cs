namespace ServiceLocation.ViewModelLocator
{
	using System;

	public interface IViewModelLocator
	{
		T Get<T>();

		object Get(Type type);
	}
}