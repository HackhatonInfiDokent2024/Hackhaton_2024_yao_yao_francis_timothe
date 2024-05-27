using MongoDB.Driver.Linq;
using MongoDB.Driver;
using ProjectWorkflow.DataAccess.DataBase;
using ProjectWorkflow.Logic.Interfaces;
using ProjectWorkflow.Logic.Services;
using ProjectWorkflow.DataAccess.Interfaces;
using ProjectWorkflow.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("LinkCs"));
var dbSettings = builder.Configuration.GetSection("LinkCs").Get<DatabaseSettings>();

builder.Services.AddSingleton<IMongoClient>(_ =>
{
    MongoClientSettings mongoSettings = MongoClientSettings.FromConnectionString(dbSettings?.ConnectionString);
    mongoSettings.LinqProvider = LinqProvider.V3;

    return new MongoClient(mongoSettings);
});

builder.Services.AddScoped<IMongoDatabase>(options =>
{
    var client = options.GetRequiredService<IMongoClient>();
    return client.GetDatabase(dbSettings?.DatabaseName);
});

builder.Services.AddScoped<IWorkflowService, WorkflowService>();
builder.Services.AddScoped<IWorkFlowRepository, WorkFlowRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
