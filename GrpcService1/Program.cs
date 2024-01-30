using GrpcService1.Services;
using Microsoft.EntityFrameworkCore;

namespace GrpcService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            string connStr = "Server=localhost\\SQLEXPRESS01;Database=grpcdb;Trusted_Connection=True;TrustServerCertificate=True";
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connStr));

            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGrpcService<UserApiService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}