using BlazorAdminLoker2022.Service;
using Microsoft.AspNetCore.Components.Authorization;


namespace BlazorAgentVs2022.Utility
{
    public static class AppSettingConfig
    {
        public static IServiceCollection AddAppSettingServiceAsync(
            this IServiceCollection services,
            string apiEndPoint_Admin)
        {
            services.AddScoped<AuthenticationStateProvider, MyAuthenticationProvider>();
            services.AddScoped<TokenControl>();
            services.AddHttpClient<ServiceAdminLoker>(x => { x.BaseAddress = new Uri(apiEndPoint_Admin); })
                .AddHttpMessageHandler<TokenControl>();
            services.AddHttpClient<ServiceAdminLogin>(x => { x.BaseAddress = new Uri(apiEndPoint_Admin); })
                .AddHttpMessageHandler<TokenControl>();
            services.AddHttpClient<ServiceAdminLaporan>(x => { x.BaseAddress = new Uri(apiEndPoint_Admin); })
                .AddHttpMessageHandler<TokenControl>();
            services.AddTransient<HttpRequestMessage>();

            //ApiPublic
            //services.AddHttpClient<ServiceApiPublic>(x => { x.BaseAddress = new Uri(apiEndPoint); });
            return services;

        }
    }
}
