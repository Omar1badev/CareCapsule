using Hangfire;
using Microsoft.AspNetCore.Identity;
using Pharmacy.Entities;
using Serilog;
using SurveyBasket;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDependencies(builder.Configuration);

builder.Host.UseSerilog((context,Configuration)=>
            Configuration.MinimumLevel.Information()
            .WriteTo.Console()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard("/jobs");
app.UseHttpsRedirection();

app.MapIdentityApi<ApplicationUser>();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
