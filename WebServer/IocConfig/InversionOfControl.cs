namespace WebServer.IocConfig
{
    public static class InversionOfControl
    {
        public static WebApplicationBuilder? AddDependencyInjection(this WebApplicationBuilder builder)            
        {
            var services = builder.Services;
            //var configuration = builder.Configuration;

            //Signleton
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<WeatherForecastService>();


            //Scoped
            services.AddScoped<IUserService, UserService>();


            //Transient

            return builder;
        }
    }
}
