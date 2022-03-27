using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SimplCommerce.Host;

namespace SimplCommerce.FunctionalTests.Bootstrap
{
    /// <summary>
    /// Web Application Factory for End to End based testing e.g. using Selenium or Playwright.
    /// </summary>
    /// <typeparam name="TEntryPoint">Program.cs in .NET. But can be any other type within the host assembly.</typeparam>
    public class TestServer<TEntryPoint> : WebApplicationFactory<TEntryPoint>
        where TEntryPoint : class
    {
        private const string LocalhostBaseAddress = "https://localhost";

        /// <summary>
        /// Initializes a new instance of the <see cref="TestServer{TEntryPoint}"/> class.
        /// Creates a new WebApplication Factory with environment, logging and webhost override.
        /// </summary>
        /// <param name="environment">Set the target environment.</param>
        /// <param name="webHostConfiguration">Override the webhost configuration.</param>
        public TestServer(string environment, Action<IWebHostBuilder> webHostConfiguration = null)
        {
            ClientOptions.BaseAddress = new Uri(LocalhostBaseAddress);
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>();
            return builder;
        }

        public string RootUri { get; private set; }
    }
}
