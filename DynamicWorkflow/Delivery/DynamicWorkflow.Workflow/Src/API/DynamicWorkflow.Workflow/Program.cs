using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
         .ReadFrom.Configuration(builder.Configuration)
         .Enrich.FromLogContext()
         .CreateLogger();
builder.Host.UseSerilog(logger);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddUnitOfWorkRepository();
//builder.Services.AddCorsConfig();
builder.Services.AddDiServices();
builder.Services.AddRateLimitings(builder.Configuration);
builder.Services.AddDbConfig(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfig();
builder.Services.AddHostedService<AddPermissionsMiddleware>();
builder.Services.AddScoped<PermissionsGroupingCheckerMiddleware, PermissionsGroupingCheckerMiddleware>();

builder.Services.AddUserManagementGrpcClients(builder.Configuration["GrpcServiceSettings:UserManagementUrl"]);

builder.Host.UseSerilog((context, configuration) => configuration
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .Enrich.FromLogContext().ReadFrom.Configuration(context.Configuration));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors",
        builder =>
        {
            builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
            //.SetIsOriginAllowed((host) => true)
            //.AllowCredentials();
        });
});
builder.Services.AddIdentityConfig(builder.Configuration);

builder.Services.AddGrpcClient(builder.Configuration);
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 15 * 1024 * 1024; // 15 MB
    options.Listen(IPAddress.Any, 7594, o => o.Protocols = HttpProtocols.Http2);
    options.Listen(IPAddress.Any, 5594, o => o.Protocols = HttpProtocols.Http1);
});

builder.WebHost.UseWebRoot("wwwroot");

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
    RequestPath = "/wwwroot"
});
app.ApplyAutoMigration();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowCors");
app.UseMiddleware<PermissionsGroupingCheckerMiddleware>();
app.MapControllers();
app.UseSerilogRequestLogging();
app.UseRateLimiter();
// add All gRPC Services 
app.AddgRPCServices();
//app.UseMiddleware<PermissionsCheckerMiddleware>();
//app.UseMiddleware<PermissionsGroupingCheckerMiddleware>();
app.Run();
