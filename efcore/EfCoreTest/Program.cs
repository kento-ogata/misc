using EfCoreTest;
using Microsoft.EntityFrameworkCore;

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

if (string.IsNullOrWhiteSpace(dbHost) ||
    string.IsNullOrWhiteSpace(dbName) ||
    string.IsNullOrWhiteSpace(dbUser) ||
    string.IsNullOrWhiteSpace(dbPassword))
{
    Console.WriteLine("Required environment variables are not found.");
    return;
}

var connectionString = $"Host={dbHost};Database={dbName};Username={dbUser};Password={dbPassword}";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestDbContext>(options => options.UseNpgsql(connectionString, options => options.UseNodaTime()));
builder.Services.AddServerSideBlazor();

var app = builder.Build();

using var context1 = app.Services.GetRequiredService<TestDbContext>();

context1.Database.EnsureDeleted();
context1.Database.EnsureCreated();

var entity = new TestEntity();
entity.OwnedEntities.Add(new TestOwnedEntity(Guid.NewGuid(), entity));

using var context2 = app.Services.GetRequiredService<TestDbContext>();

context2.TestEntities.Add(entity);

await context2.SaveChangesAsync();

Console.WriteLine($"OwnedEntities.Count: {entity.OwnedEntities.Count}");

app.Run();
