using Microsoft.EntityFrameworkCore;
using WebApplicationTraining.Di;
using WebApplicationTraining.Models;
using WebApplicationTraining.Repositories;
using WebApplicationTraining.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Inject the implementation class 
builder.Services.AddSingleton<IMail, Gmail>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepositorySqlServer>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var connStr = builder.Configuration["ConnectionStrings:NorthwindContext"];
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<NorthwindContext>(options => options.UseSqlServer(connStr));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    
}

app.UseCors("AllowAll"); 
app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
