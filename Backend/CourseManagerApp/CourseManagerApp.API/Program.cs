
using CourseManagerApp.Business.Contracts;
using CourseManagerApp.Business.Services;
using CourseManagerApp.Data.Contracts;
using CourseManagerApp.Data.Repositories;
using CourseManagerApp.Data;
using Microsoft.EntityFrameworkCore;
using CourseManagerApp.Entities;

namespace CourseManagerApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");



            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));


            builder.Services.AddScoped<IRepository<Course>>(provider =>
            {
                var context = provider.GetRequiredService<DatabaseContext>();
                return new BaseRepository<Course>(context);
            });

            builder.Services.AddScoped<ICourseRepository>(provider =>
            {
                var context = provider.GetRequiredService<DatabaseContext>();
                return new CourseRepository(context);
            });

            builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            builder.Services.AddScoped<ICourseService, CourseService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
