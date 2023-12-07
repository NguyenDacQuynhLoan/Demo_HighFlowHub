using Microsoft.EntityFrameworkCore;
using HighFlowHub;
using System.Reflection;
using HighFlowHub.Services;
using RedisCache.Core;

// Connect DB
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContext>(e =>
    e.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase"))
);

// Register Redis Cache
builder.Services.AddRedisCache(option =>
    {
        option.Configuration = builder.Configuration["RedisCache:Connection"];
        option.InstanceName = builder.Configuration["RedisCache:InstanceName"];
        // option.Configuration = "localhost:6379,abortConnect=false,connectTimeout=30000,responseTimeout=30000";
        // option.InstanceName = "RedisCacheDB";
    }
);

// Register services
var serviceAssembly = Assembly.GetExecutingAssembly();
if (serviceAssembly != null)
{
    var serviceTypes = serviceAssembly.ExportedTypes.Where(e 
        => e.IsClass && e.Namespace == "HighFlowHub.Services"
    );
    foreach (var service in serviceTypes)
    {
        if(service != null)
        {
            if (service.Name.Contains("BaseService"))
            {
                continue;
            }

            //var serviceInterface = service.GetInterface($"I{service.Name}");
            //if (serviceInterface != null){}
            builder.Services.AddScoped(service);
        }
    }
}

builder.Services.AddControllers();
    
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(e =>e
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
