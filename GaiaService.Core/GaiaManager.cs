using System.Threading.Tasks;

namespace GaiaService.Core
{

	public class GaiaManager : IGaiaManager
	{
		public Task<string> SayHello(string name)
		{
			return Task.FromResult($"Hello {name}");
		}
	}
}
