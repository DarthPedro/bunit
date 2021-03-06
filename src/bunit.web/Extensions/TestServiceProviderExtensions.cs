using Bunit.Diffing;
using Bunit.Mocking.JSInterop;
using Bunit.Rendering;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace Bunit.Extensions
{
	/// <summary>
	/// Helper methods for correctly registering test dependencies
	/// </summary>
	public static class TestServiceProviderExtensions
	{
		/// <summary>
		/// Registers the default services required by the web <see cref="TestContext"/>.
		/// </summary>
		public static IServiceCollection AddDefaultTestContextServices(this IServiceCollection services)
		{
			services.AddSingleton<IJSRuntime>(new PlaceholderJsRuntime());
			services.AddSingleton<HtmlComparer>(srv => new HtmlComparer());
			services.AddSingleton<HtmlParser>(srv => new HtmlParser(
					srv.GetRequiredService<ITestRenderer>(),
					srv.GetRequiredService<HtmlComparer>()
				)
			);
			return services;
		}
	}
}
