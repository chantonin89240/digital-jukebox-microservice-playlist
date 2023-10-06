using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration); //DI de la couche Infrastructure

var app = builder.Build();

//CreateHostBuilder(args).Build().Run();

//static IHostBuilder CreateHostBuilder(string[] args) =>
//           Host.CreateDefaultBuilder(args)
//               .ConfigureLogging(logging =>
//               {
//                   logging.ClearProviders();
//                   logging.AddConsole();
//               })
//               .ConfigureWebHostDefaults(webBuilder =>
//               {
                   
//               });

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