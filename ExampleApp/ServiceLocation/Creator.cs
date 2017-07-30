namespace ServiceLocation
{
	using Ninject;

	public class Creator
	{
		public Creator(IKernel kernel)
		{
			ServiceLocator.CreateInstance(kernel);
		}
	}
}