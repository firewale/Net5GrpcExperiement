using Autofac;

namespace GaiaService.Core
{
	public class GaiaAutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<GaiaManager>()
				.As<IGaiaManager>()
				.SingleInstance();
		}
	}
}
