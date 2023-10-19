using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Extensions.NETCore.Setup;
using ConviteOnline.Application.Interfaces;
using ConviteOnline.Application.Mappings;
using ConviteOnline.Application.Services;
using ConviteOnline.Application.Utils;
using ConviteOnline.Domain.Interfaces;
using ConviteOnline.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConviteOnline.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Get the AWS profile information from configuration providers
            AWSOptions awsOptions = configuration.GetAWSOptions();

            // Configure AWS service clients to use these credentials
            services.AddDefaultAWSOptions(awsOptions);

            services.AddAWSService<IAmazonDynamoDB>();
            services.AddScoped<IDynamoDBContext, DynamoDBContext>();

            services.AddSingleton<AmazonS3ClientUtil>(c => AmazonS3ClientUtil.IniciarlizacaoS3(configuration));


            //Repositorios
            services.AddScoped<IFotoRepositorio, FotoRepositorio>();
            services.AddScoped<IRespostaRepositorio, RespostaRepositorio>();

            //Services
            services.AddScoped<IFotoService, FotoService>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IRespostaService, RespostaService>();

            services.AddAutoMapper(typeof(MappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("ConviteOnline.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

            return services;
        }
    }
}
