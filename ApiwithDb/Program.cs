using ApiwithDb;
using ApiwithDb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyContext>(Options =>
    Options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));
builder.Services.AddScoped<Response>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        
    });
});


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
