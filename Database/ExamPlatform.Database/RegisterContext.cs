using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExamPlatform.Database
{
    public static class RegisterContext
	{
		public static IServiceCollection AddDbContext(IServiceCollection services, string nameOrConnectionString)
		{
			services.AddDbContext<ExamPlatformContext>(options =>
			{
				options.UseNpgsql(
					nameOrConnectionString,
					b => b.MigrationsAssembly(typeof(ExamPlatformContext).GetTypeInfo().Assembly.ToString())
				);
			});

			return services;
		}

		public static ContainerBuilder Register(ContainerBuilder builder, string nameOrConnectionString)
		{
			return SetupIoC(builder, nameOrConnectionString);
		}

		private static ContainerBuilder SetupIoC(ContainerBuilder builder, string nameOrConnectionString)
		{
			builder.RegisterType<DbContextOptions<ExamPlatformContext>>()
				.WithParameter(new NamedParameter("nameOrConnectionString", nameOrConnectionString))
				.AsSelf();

			builder.RegisterType<ExamPlatformContext>()
				.AsSelf()
				.WithParameter(new NamedParameter("nameOrConnectionString", nameOrConnectionString))
				.InstancePerLifetimeScope();
			
			return builder;
		}
	}
}
