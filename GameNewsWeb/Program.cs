using GameNewsWeb.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
var databasePrivateUrl = Environment.GetEnvironmentVariable("DATABASE_PRIVATE_URL");
var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? Environment.GetEnvironmentVariable("PGHOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? Environment.GetEnvironmentVariable("PGPORT") ?? "5432";
var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? Environment.GetEnvironmentVariable("PGDATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? Environment.GetEnvironmentVariable("PGUSER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? Environment.GetEnvironmentVariable("PGPASSWORD");

static string BuildNpgsqlConnectionStringFromUrl(string url)
{
    if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
    {
        return url;
    }

    if (uri.Scheme is not ("postgres" or "postgresql"))
    {
        return url;
    }

    var userInfo = uri.UserInfo.Split(':', 2);
    var username = userInfo.Length > 0 ? Uri.UnescapeDataString(userInfo[0]) : string.Empty;
    var password = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : string.Empty;
    var database = uri.AbsolutePath.Trim('/');

    var builder = new NpgsqlConnectionStringBuilder
    {
        Host = uri.Host,
        Port = uri.IsDefaultPort ? 5432 : uri.Port,
        Database = database,
        Username = username,
        Password = password,
        SslMode = SslMode.Require
    };

    return builder.ConnectionString;
}

// Railway/production: use PostgreSQL from env vars.
// Local dev fallback: keep SQL Server connection from appsettings.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var postgresUrl = !string.IsNullOrWhiteSpace(databasePrivateUrl) ? databasePrivateUrl : databaseUrl;
    if (!string.IsNullOrWhiteSpace(postgresUrl))
    {
        options.UseNpgsql(BuildNpgsqlConnectionStringFromUrl(postgresUrl));
        return;
    }

    if (!string.IsNullOrWhiteSpace(dbHost) &&
        !string.IsNullOrWhiteSpace(dbName) &&
        !string.IsNullOrWhiteSpace(dbUser))
    {
        var postgresConnectionString =
            $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword};SSL Mode=Require";
        options.UseNpgsql(postgresConnectionString);
        return;
    }

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    var allowedOriginsFromEnv = Environment.GetEnvironmentVariable("CORS_ALLOWED_ORIGINS");
    var allowedOrigins = string.IsNullOrWhiteSpace(allowedOriginsFromEnv)
        ? new[]
        {
            "https://html-production-2494.up.railway.app",
            "http://localhost:3000",
            "http://127.0.0.1:5500"
        }
        : allowedOriginsFromEnv
            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(origin => origin.TrimEnd('/'))
            .ToArray();

    options.AddPolicy("FrontendCors", policy =>
        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod());
});
// MVC (контроллеры + представления)
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (db.Database.IsNpgsql())
    {
        db.Database.EnsureCreated();
    }
    else
    {
        db.Database.Migrate();
    }
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("FrontendCors");

app.UseAuthorization();

// Маршруты MVC
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Games}/{action=Index}/{id?}");

var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrWhiteSpace(port))
{
    app.Urls.Add($"http://*:{port}");
}

app.Run();