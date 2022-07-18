
using Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add Db Context
builder.Services.AddDbContext<projMasters.Database.MasterContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PextaHrmsMsSql")));
// Add services to the container.
builder.Services.AddScoped<ISettings>(srv => new projMasters.Settings(srv.GetRequiredService<projMasters.Database.MasterContext>(), srv.GetRequiredService<IConfiguration>(),srv.GetRequiredService<IHttpContextAccessor>()));
builder.Services.AddScoped<projMasters.IMasters>(srv => new projMasters.Masters(srv.GetRequiredService<projMasters.Database.MasterContext>()));
builder.Services.AddScoped<projMasters.IAuth>(srv => new projMasters.Auth(srv.GetRequiredService<projMasters.Database.MasterContext>(),srv.GetRequiredService<ISettings>()));
////////////////
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", b => {
        b.WithOrigins("http://localhost:4200", "https://localhost:44445")
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials();
    });
});

builder.Services.AddControllers();
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

app.UseCors("DefaultCorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
