using System.Threading.Tasks;

namespace GaiaService.Core
{
	public interface IGaiaManager
	{
		Task<string> SayHello(string name);
	}
}
