using HRMS.classes.repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Connection string 
//builder.Services.AddDbContext<HRMS.Database.HRMSContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("PextaHrms")));
builder.Services.AddDbContext<HRMS.Database.HRMSContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PextaHrmsMsSql")));
builder.Services.AddScoped<IserEmployee>(srv => new serEmployee(srv.GetRequiredService<HRMS.Database.HRMSContext>()));
var app = builder.Build();

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
