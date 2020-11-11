using Gaia;
using Grpc.Net.Client;
using System.Net.Http;
using System.Net.Sockets;

namespace GaiaService.Client
{

	public class GaiaClient
	{
		public static readonly string SocketPath = @"C:\Ripcord\GaiaService.tmp";

		private Gaia.GaiaService.GaiaServiceClient _client;

		public GaiaClient()
		{
			var channel = CreateChannel();
			_client = new Gaia.GaiaService.GaiaServiceClient(channel);
		}

		public string SendGreet(string name)
		{
			var request = new HelloRequest
			{
				Name = name
			};

			var response = _client.SayHello(request);

			return response.Message;
		}

		public static GrpcChannel CreateChannel()
		{
			var udsEndPoint = new UnixDomainSocketEndPoint(SocketPath);
			var connectionFactory = new UnixDomainSocketConnectionFactory(udsEndPoint);
			var socketsHttpHandler = new SocketsHttpHandler
			{
				ConnectCallback = connectionFactory.ConnectAsync
			};

			return GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
			{
				HttpHandler = socketsHttpHandler
			});
		}
	}
}
