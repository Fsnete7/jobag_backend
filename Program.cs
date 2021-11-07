using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using jobagapi.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace jobagapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Para usar datos de prueba
            
            var host = CreateHostBuilder(args).Build();
            
            using(var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                context.Database.EnsureCreated();
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
