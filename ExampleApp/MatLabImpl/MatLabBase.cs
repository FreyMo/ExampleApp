namespace MatLabImpl
{
	using Common.Notification;

	public class MatLabBase : BindableBase
	{
		public static int GetFuncResult()
		{
			return new MathLibNativeWrapper().AddAsync(3, 6).Result;
		}
	}
}