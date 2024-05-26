using Microsoft.AspNetCore.Diagnostics;
using Takealittle.Api;
using Takealittle.Application;
using Takealittle.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddOAuthConfig(builder.Configuration);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", b =>
    {
        b.WithOrigins("https://accounts.google.com") 
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
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Takealittle API");
        x.OAuthClientId(builder.Configuration.GetValue<string>("GoogleAuth:ClientId"));
        x.OAuthClientSecret(builder.Configuration.GetValue<string>("GoogleAuth:ClientSecret"));
    });
}

app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext context) =>
{
    Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

    return Results.Problem();
});
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();

app.Run();
