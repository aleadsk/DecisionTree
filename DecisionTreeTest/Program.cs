using DecisionTreeTest.Data;
using Serilog;
using Serilog.Events;
using Volo.Abp.Data;
using Volo.Abp.Modularity.PlugIns;

namespace DecisionTreeTest;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        var loggerConfiguration = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console());

        if (IsMigrateDatabase(args))
        {
            loggerConfiguration.MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning);
            loggerConfiguration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
        }

        Log.Logger = loggerConfiguration.CreateLogger();
		try
		{
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddApplication<DecisionTreeTestModule>(options => {
				options.PlugInSources.AddFolder(@"C:\Users\aless\OneDrive\�rea de Trabalho\DecisionTree\Temp\TextWebPlugIn", SearchOption.AllDirectories);
			});
			builder.Services.AddMongoDbContext<DecisionTreeTestDbContext>(options => {
				options.AddDefaultRepositories(); 
                options.AddDefaultRepositories(includeAllEntities: true);
			});
			builder.Services.AddApplicationInsightsTelemetry();
			builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            if (IsMigrateDatabase(args))
            {
                builder.Services.AddDataMigrationEnvironment();
            }
            var app = builder.Build();
            await app.InitializeApplicationAsync(); 

			if (IsMigrateDatabase(args))
            {
                await app.Services.GetRequiredService<DecisionTreeTestDbMigrationService>().MigrateAsync();
                return 0;
			}

			app.Use(next => context => {
				context.Request.Headers.Remove("RequestVerificationToken");
				return next(context);
			});

			Log.Information("Starting DecisionTreeTest.");
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "DecisionTreeTest terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static bool IsMigrateDatabase(string[] args)
    {
        return args.Any(x => x.Contains("--migrate-database", StringComparison.OrdinalIgnoreCase));
    }
}