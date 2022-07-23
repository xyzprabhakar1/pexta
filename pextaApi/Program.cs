
using Common;
using Common.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using pextaApi;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//Add Db Context
builder.Services.AddDbContext<projMasters.Database.MasterContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PextaHrmsMsSql")));

// Add services to the container.
builder.Services.AddScoped<ICurrentUser>(srv => new projMasters.CurrentUser(srv.GetRequiredService<IHttpContextAccessor>()));
builder.Services.AddScoped<ISettings>(srv => new projMasters.Settings(srv.GetRequiredService<projMasters.Database.MasterContext>(), srv.GetRequiredService<IConfiguration>(),srv.GetRequiredService<IHttpContextAccessor>()));
builder.Services.AddScoped<projMasters.IMasters>(srv => new projMasters.Masters(srv.GetRequiredService<projMasters.Database.MasterContext>()));
builder.Services.AddScoped<projMasters.IAuth>(srv => new projMasters.Auth(srv.GetRequiredService<projMasters.Database.MasterContext>(),srv.GetRequiredService<ISettings>()));

////////////////
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", b => {
        b.WithOrigins(builder.Configuration.GetSection("ProjectUrls")?.GetChildren()?.Select(x=>x.Value)?.ToArray() )
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials();
    });
});

//add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    };
});


builder.Services.AddAuthorization(options =>
{
    foreach (enmDocumentMaster _enm in Enum.GetValues(typeof(enmDocumentMaster)))
    {
        var DocumentType = _enm.GetDocumentDetails().DocumentType;
        options.AddPolicy(_enm.ToString() + enmDocumentType.Create.ToString(), policy => policy.Requirements.Add(new AccessRightRequirement(_enm, enmDocumentType.Create,enmAdditionalClaim.None)));
        options.AddPolicy(_enm.ToString() + enmDocumentType.Update.ToString(), policy => policy.Requirements.Add(new AccessRightRequirement(_enm, enmDocumentType.Update, enmAdditionalClaim.None)));
        options.AddPolicy(_enm.ToString() + enmDocumentType.Approval.ToString(), policy => policy.Requirements.Add(new AccessRightRequirement(_enm, enmDocumentType.Approval, enmAdditionalClaim.None)));
        options.AddPolicy(_enm.ToString() + enmDocumentType.Delete.ToString(), policy => policy.Requirements.Add(new AccessRightRequirement(_enm, enmDocumentType.Delete, enmAdditionalClaim.None)));
        options.AddPolicy(_enm.ToString() + enmDocumentType.Report.ToString(), policy => policy.Requirements.Add(new AccessRightRequirement(_enm, enmDocumentType.Report, enmAdditionalClaim.None)));
        options.AddPolicy(_enm.ToString() + enmDocumentType.DisplayMenu.ToString(), policy => policy.Requirements.Add(new AccessRightRequirement(_enm, enmDocumentType.DisplayMenu, enmAdditionalClaim.None)));
        options.AddPolicy(_enm.ToString() + enmDocumentType.PendingReport.ToString(), policy => policy.Requirements.Add(new AccessRightRequirement(_enm, enmDocumentType.PendingReport, enmAdditionalClaim.None)));
        options.AddPolicy(_enm.ToString() + enmDocumentType.DetailView.ToString(), policy => policy.Requirements.Add(new AccessRightRequirement(_enm, enmDocumentType.DetailView, enmAdditionalClaim.None)));
    }

    foreach (enmAdditionalClaim _enm in Enum.GetValues(typeof(enmAdditionalClaim)))
    {
        options.AddPolicy(enmDocumentMaster.None.ToString()+ _enm.ToString(), policy => policy.Requirements.Add(new AccessRightRequirement(enmDocumentMaster.None,enmDocumentType.None,_enm)));
    }

});
builder.Services.AddScoped<IAuthorizationHandler, AccessRightHandler>();


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
