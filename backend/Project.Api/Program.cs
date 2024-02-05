global using Project.Api.Models;
global using Project.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MinisterulFinantelorContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies((typeof(Program).Assembly)));

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
     var frontendURL = configuration.GetValue<string>("FrontendURL");

     options.AddDefaultPolicy(builder =>
     {
          builder.WithOrigins(frontendURL)
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();

     });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
