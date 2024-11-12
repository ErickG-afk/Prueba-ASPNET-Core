using DataBase.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


//A�adir el contexto a DBContext y pasarle la cadena de conexi�n almacenada en el archivo de config json
builder.Services.AddDbContext<ToDoContext>( options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DataBase"));
});

var app = builder.Build();

//Asegurarnos de crear la Base de datos con las tablas usando code first al inicializar la aplicaci�n
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
