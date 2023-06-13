using API.Extensions;
using API.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;
using Tickets.Application;
using Tickets.Domain.Settings;
using Tickets.Infraestructure.Identity.Extensions;
using Microsoft.Extensions.Configuration;
using Tickets.Infraestructure.Shared.Extensions;
using Tickets.Infraestructure.Persistence;
using Tickets.Infraestructure.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddIdentityInfraestructure(builder.Configuration)
                .AddSharedInfraestructure()
                .AddApplicationLayer(builder.Configuration)
                .AddPersistenceLayer(builder.Configuration)
                .AddEndpointsApiExplorer()
                .ConfigureSwagger();

builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("Email"));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocExpansion(DocExpansion.None);
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//Global Exception Handling
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TicketDBContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
