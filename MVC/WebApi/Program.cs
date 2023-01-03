using Microsoft.EntityFrameworkCore;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string ProconString = builder.Configuration.GetConnectionString("Product");
builder.Services.AddDbContext<myDemoDBContext>(a => a.UseSqlServer(ProconString));

builder.Services.AddControllers();

var MyAllowSpecificOrigins = "AllowAny";    //此為公開策略的名稱(為了繞過COR限制)
builder.Services.AddCors(x =>
{
    x.AddPolicy(                            //新增權限(參數有name和policy)
        name: MyAllowSpecificOrigins,
        policy => policy.WithOrigins("*").WithHeaders("*").WithMethods("*")
        );              //來源是此API輸出的網址，如果要全公開就給*就好，要限定Headers或Methods的話也是
});


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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
