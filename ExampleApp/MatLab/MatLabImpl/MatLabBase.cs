namespace MatLabImpl
{
	using System.Threading.Tasks;
	using Common.Notification;

	public class MatLabBase : BindableBase
	{
		public static int GetFuncResult()
		{
			return Task.Run(() => new MathLibNativeWrapper().Add(3, 6)).Result;
		}
	}
}