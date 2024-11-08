using Microsoft.EntityFrameworkCore;
using WebApiDemokrataPerson.Context;

var builder = WebApplication.CreateBuilder(args);


//Variable para conection String
var connectionStr = builder.Configuration.GetConnectionString("conn");
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(connectionStr));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Aseguramos que siempre se ejecuten los Migrations.
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}


//Configurando el HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
