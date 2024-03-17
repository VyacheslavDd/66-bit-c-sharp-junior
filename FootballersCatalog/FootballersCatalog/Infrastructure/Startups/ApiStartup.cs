using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;

namespace FootballersCatalog.Infrastructure.Startups
{
	public static class ApiStartup
	{
		public static IServiceCollection TryAddApi(this IServiceCollection services)
		{
			services.AddControllers().AddNewtonsoftJson(setup =>
			{
				setup.SerializerSettings.Converters.Add(new StringEnumConverter()
				{
					NamingStrategy = new CamelCaseNamingStrategy()
				});
				setup.SerializerSettings.DateFormatString = "yyyy-MM-dd";
			}).AddJsonOptions(config => config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
			return services;
		}
	}
}
