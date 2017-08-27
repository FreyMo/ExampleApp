namespace ServiceLocation
{
	using IoC;

	public class Creator
	{
		public Creator(IIoCContainer container)
		{
			ServiceLocator.CreateInstance(container);
		}
	}
}