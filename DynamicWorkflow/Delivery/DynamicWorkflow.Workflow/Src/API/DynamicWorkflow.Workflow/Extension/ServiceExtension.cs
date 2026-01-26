
using _4EPlatForm.Application.Helpers;

namespace WorkFlow.DynamicWorkFlow.Extension
{
    public static class ServiceExtension
    {
        public static void AddUnitOfWorkRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
        }
        public static void AddDiServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationLayer)));
            services.AddAutoMapper((typeof(ApplicationLayer)));
            services.AddHttpContextAccessor();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IResponseHelper, ResponseHelper>();
            services.AddScoped<GlobalExceptionHandler, GlobalExceptionHandler>();
            services.AddScoped<IActionTakerAuthorization, ActionTackerAuthorization>();
            services.AddScoped<IStepProcessor, StepProcessor>();
            //  services.AddScoped<IHanderSender, ComitteSender>();
            services.AddScoped<ISentRequestStatus, SentRequestStatus>();
            services.AddScoped<IDetectSender, DetectSender>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAddExceptionActionTackersNextStep, AddExceptionActionTackersNextStep>();
            services.AddScoped<IUsers, Users>();
            services.AddScoped<IAcceptDuplicationUser, AcceptDuplicationUser>();
            services.AddScoped<IRequestIncoming, RequestIncoming>();
            services.AddScoped<ILoadRequestIncoming, LoadRequestIncoming>();
            services.AddHostedService<StartupHostedService>();

        }
        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCors",
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        //.WithOrigins("http://localhost:3000")
                        .AllowAnyOrigin()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                    });
            });
        }

        public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(options =>
         {
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
             options.LogTo(Console.WriteLine, LogLevel.Information);
             options.EnableSensitiveDataLogging(true);
             options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
         });
        }
        public static void AddRateLimitings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRateLimiter(options =>
            {
                var rateLimitSection = configuration.GetSection("RateLimit");
                var permitLimit = rateLimitSection.GetValue<int>("PermitLimit");
                var queueLimit = rateLimitSection.GetValue<int>("QueueLimit");
                var windowSeconds = rateLimitSection.GetValue<int>("WindowSeconds");
                options.AddFixedWindowLimiter("FixedWindowPolicy", opt =>
                {
                    opt.Window = TimeSpan.FromSeconds(windowSeconds);
                    opt.PermitLimit = permitLimit;
                    opt.QueueLimit = queueLimit;
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                }).RejectionStatusCode = 429;
            });
        }
        public static void ApplyAutoMigration(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<DBContext>();
                var serviceProvider = serviceScope.ServiceProvider;
                if (!serviceScope.ServiceProvider.GetService<DBContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<DBContext>().Migrate();
                }
                ContextSeedData.Seed(dbContext);
            }
        }
        public static void AddGrpcClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpc();
            services.AddGrpcReflection();
            services.AddDynamicWorkFlowAggClients(configuration["GrpcServiceSettings:DynamicWorkFlowAggUrl"]);
            services.AddUserManagementGrpcClients(configuration["GrpcServiceSettings:UserManagementUrl"]);
            services.AddCommiteGrpcClients(configuration["GrpcServiceSettings:CommitteesUrl"]);
            services.AddPmoGrpcClients(configuration["GrpcServiceSettings:PmoUrl"]);
            services.AddTrainingGrpcClients(configuration["GrpcServiceSettings:TrainingUrl"]);
            services.AddRiskGrpcClients(configuration["GrpcServiceSettings:RiskUrl"]);

        }
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition(
                "token",
                new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Name = HeaderNames.Authorization
                }
                    );
                c.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "token"
                            },
                        },
                        Array.Empty<string>()
                    }
                }
                    );
            });
        }
        public static void AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        // the name of your api resources   
                        options.Audience = "UserManagementServer";
                        /// identity server url                    
                        options.Authority = configuration.GetValue<string>("IdentityUrl");
                        options.RequireHttpsMetadata = false;
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ResourceOwnerPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireClaim("scope", "4EMicroServices"); // Require scope associated with Resource Owner Password token
                });

                options.AddPolicy("ClientCredentialsPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireClaim("scope", "CPAggregatorAPI"); // Require scope associated with Client Credentials token
                });
            });
        }
    }
}
