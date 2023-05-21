using Ocelot.DependencyInjection; //For Dependency Injection
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
var app = builder.Build();

builder.Services.AddOcelot(builder.Configuration).AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});
builder.Services.AddSwaggerForOcelot(builder.Configuration);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerForOcelotUI(opt => {
        opt.PathToSwaggerGenerator = "/swagger/docs";
    });
}



app.MapGet("/", () => "Hello World!");

app.Run();
