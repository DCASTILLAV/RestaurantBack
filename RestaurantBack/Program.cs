using RestaurantBack.Domain.UnitOfWork;
using RestaurantBack.Infrastructure.BusinessLogic.Person;
using RestaurantBack.Infrastructure.BusinessLogic.Product;
using RestaurantBack.Infrastructure.BusinessLogic.Sales;
using RestaurantBack.Infrastructure.UnitOfWork;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    // PRODUCCION
    //options.AddPolicy(name: MyAllowSpecificOrigins,
    //              app =>
    //              {
    //                  app.WithOrigins(
    //                      "http://dulfris2024-001-site1.atempurl.com")
    //                        .AllowAnyMethod()
    //                       .AllowAnyHeader()
    //                       .AllowCredentials();
    //              }

    //);

    //Desarrollo
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        app =>
        {
            app.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        }
    );
});
builder.Services.AddControllers();

builder.Services.AddSingleton<IDapperUnitOfWork>(opcion => new DapperUnitOfWork(builder.Configuration.GetConnectionString("RESTAURANT")));

builder.Services.AddTransient<IProductBL, ProductBL>();
builder.Services.AddTransient<IPersonBL, PersonBL>();
builder.Services.AddTransient<ISalesBL, SalesBL>();

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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
