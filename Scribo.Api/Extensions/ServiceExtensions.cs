using Microsoft.EntityFrameworkCore;
using OpenAI;
using Scribo.Core.Interfaces;
using Scribo.Infrastructure.Repositories;
using Scribo.Service;
using System.ClientModel;

namespace Scribo.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        //public static IServiceCollection ConfigureOpenAiServices(
        //    this IServiceCollection services,
        //    IConfiguration configuration)
        //{
        //    var openAiKey = configuration["OpenAI:ApiKey"]
        //        ?? throw new InvalidOperationException("OpenAI:ApiKey yapılandırılmamış.");

        //    services.AddSingleton(_ => new OpenAIClient(
        //        new ApiKeyCredential(openAiKey),
        //        new OpenAIClientOptions
        //        {
        //            NetworkTimeout = TimeSpan.FromMinutes(5)
        //        }));

        //    services.AddScoped<IAudioTranscriptionService, WhisperTranscriptionService>();
        //    services.AddScoped<ITextSummarizationService, GptSummarizationService>();

        //    return services;
        //}
        public static IServiceCollection ConfigureOpenAiServices(
    this IServiceCollection services,
    IConfiguration configuration)
        {
            var openAiKey = configuration["OpenAI:ApiKey"];

            if (!string.IsNullOrWhiteSpace(openAiKey))
            {
                services.AddSingleton(_ => new OpenAIClient(
                    new ApiKeyCredential(openAiKey),
                    new OpenAIClientOptions
                    {
                        NetworkTimeout = TimeSpan.FromMinutes(5)
                    }));
            }
            else { services.AddSingleton(_ => new OpenAIClient(new ApiKeyCredential("test-key"))); }

                services.AddScoped<IAudioTranscriptionService, WhisperTranscriptionService>();
            services.AddScoped<ITextSummarizationService, GptSummarizationService>();

            return services;
        }
    }
}
