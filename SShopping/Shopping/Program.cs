using Microsoft.EntityFrameworkCore;
using Shopping.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuracion la conexion de la base de datos
builder.Services.AddDbContext<DataContext>(op => 
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Inyecciones segun el ciclo de vida del objeto
builder.Services.AddTransient<SeedDb>(); //lo uso una sola vez cuando lo necesita y lo destruye, - veces se lo usa
//builder.Services.AddScoped<SeedDb>();   // cada vez que lo necesita lo inyecta y lo destruye al dejar de usar, + usados
//builder.Services.AddSingleton<SeedDb>(); //lo inyecta una vez y no lo destruye lo deja en memoria

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

SeedData();

void SeedData()
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service.SeedAsync().Wait();
    }
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
