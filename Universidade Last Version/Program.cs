using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Universidade.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EscolaContexto>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    //Resolve dbcontext with DI help
    var dbcontext = (EscolaContexto)scope.ServiceProvider.GetService(typeof(EscolaContexto));

    //call your static method herer
    DbInitializer.Initialize(dbcontext);
}

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
