using DotNetEnv;
using genscoSQLProject1.Data;
using genscoSQLProject1;
using Microsoft.EntityFrameworkCore;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Repository;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Configuration.AddEnvironmentVariables();
var connectionString = Environment.GetEnvironmentVariable("SQL_API");
//Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddLogging(config =>
{
    config.AddConsole();  
    config.AddDebug();    
});


builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IChecklistItemRepository, ChecklistItemRepository>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IBranchInspectionRepository, BranchInspectionRepository>();
//builder.Services.AddScoped<IAssetItemsRepository, AssetItemsRepository>();
//builder.Services.AddScoped<IFormAssetsRepository, FormAssetsRepository>();
//builder.Services.AddScoped<IFormCategoryRepository, FormCategoryRepository>();
//builder.Services.AddScoped<IFormItemsRepository, FormItemsRepository>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);




void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
