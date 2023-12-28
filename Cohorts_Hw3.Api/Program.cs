
using Cohorts_Hw3.Api.Mapping;
using Cohorts_Hw3.Business.Abstract;
using Cohorts_Hw3.Business.Concrete;
using Cohorts_Hw3.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Cohorts_Hw3.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDbContext"));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}