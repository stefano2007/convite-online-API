namespace ConviteOnline.API.Extensions
{
    public static class CorsSetup
    {
        public static IServiceCollection ConfigCors(this IServiceCollection services)
        {
            services.AddCors(cfg => {
                cfg.AddDefaultPolicy(policy => {
                    policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .SetIsOriginAllowedToAllowWildcardSubdomains() //Habilitar CORS para todos os Subdomínios
                        .AllowAnyHeader();
                });

                //Habilitar todos os site, com restrição.
                cfg.AddPolicy("AnyOrigin", policy => {
                    policy.AllowAnyOrigin()
                          .WithMethods("GET")
                          .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
