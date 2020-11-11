using Gaia;
using GaiaService.Core;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Net5GrpcExperiement
{
	public class GaiaService : Gaia.GaiaService.GaiaServiceBase
	{
		private readonly ILogger<GaiaService> _logger;
		private readonly IGaiaManager _gaiaManager;

		public GaiaService(
			ILogger<GaiaService> logger,
			IGaiaManager gaiaManager)
		{
			_logger = logger;
			_gaiaManager = gaiaManager;
		}

		public async override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			var message = await _gaiaManager.SayHello(request.Name);

			return new HelloReply
			{
				Message = message
			};
		}
	}
}
