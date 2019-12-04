using Autofac;
using ExamPlatform.Database;
using ExamPlatform.Service.Services;

namespace ExamPlatform.Service
{
    public class RegisterServices
	{
		public static void Register(ContainerBuilder builder)
		{
			SetupIoC(builder);
		}

		private static void SetupIoC(ContainerBuilder builder)
		{
			RegisterContext.Register(builder, "ExamPlatformContext");

			builder.RegisterAssemblyTypes(typeof(TestService).Assembly)
				.Where(t =>
					t.Name.EndsWith("Service") &&
					t.Namespace != null &&
					t.Namespace.StartsWith("ExamPlatform.Service.Services"))
				.AsImplementedInterfaces()
				.AsSelf()
				.PropertiesAutowired();
		}
	}
}
