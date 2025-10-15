using HospitalManagementSystem2025.Repositories;
using HospitalManagementSystem2025.Services;

namespace HospitalManagementSystem2025
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register all custom services like connectionString,repositories,services

            // 1 - Add connection string
            var connectionString = builder.Configuration.GetConnectionString("MVCConnectionString");

            // 2 - Repository and service as middleware
            builder.Services.AddScoped<IPatientRepository, PatientRepositoryImpl>();
            builder.Services.AddScoped<IPatientService, PatientServiceImpl>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Patient}/{action=List}/{id?}");

            app.Run();
        }
    }
}