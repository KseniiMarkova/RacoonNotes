using AuthService.Configuration;
using RacoonNotes.MessageBroker.Models;
using RacoonNotes.MongoDbConnector.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MessageBrokerSettings>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));


builder.Services
    .AddAuthServiceConfig(builder.Configuration)
    .AddAuthServiceDependencyGroup()
    .AddMongoDbConnectorDependencyGroup()
    .AddMessageBrokerDependencyGroup();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

MessageHandlerSubscriptions.ConfigureMessageBroker(app);

app.Run();
