using ASPrazorpages_2.Services;
using ASPrazorpages_2.Services.implementations;

namespace ASPrazorpages_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IGreetingService, GreetingService>(); // registering custom service(one we created)


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // for www.root

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages(); //matching routes and files

            app.Run();
        }
    }
}
