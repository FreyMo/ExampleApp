namespace MatLabImpl
{
	using System.Threading.Tasks;
	using Common.Notification;

	public class MatLabBase : BindableBase
	{
		public static int GetFuncResult()
		{
			return Task.Run(() => new MathLibNativeWrapper().AddAsync(3, 6)).Result;
		}
	}
}