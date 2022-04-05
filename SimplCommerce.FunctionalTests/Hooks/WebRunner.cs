//using Microsoft.AspNetCore.Mvc.Testing;

//namespace SimplCommerce.FunctionalTests.Hooks
//{
//    [Binding]
//    public static class WebRunner
//    {
//        public static Uri Uri => _server.ClientOptions.BaseAddress;

//        // In .NET 6 - we don't have to pick a Startup.cs class.
//        // Instead, we can pick any class as long as it is within web api.
//        // It uses the assembly inside to get all that it needs.
//        private static WebApplicationFactory<Program> _server;

//        [BeforeTestRun]
//        public static void Start()
//        {
//            _server = new WebApplicationFactory<Program>();
//        }

//        [AfterTestRun]
//        public static void Stop()
//        {
//            //_client.Dispose();
//            _server.Dispose();
//        }
//    }
//}
