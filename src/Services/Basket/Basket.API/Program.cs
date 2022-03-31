using Basket.API.GrpcServices;
using Basket.API.Repositories;

using Discount.Grpc.Protos;

using MassTransit;

var builder = WebApplication.CreateBuilder(args);
 

// Redis Configuration
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});

// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config => {
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});
builder.Services.Configure<MassTransitHostOptions>(options =>
{
    options.WaitUntilStarted = true;
    options.StartTimeout = TimeSpan.FromSeconds(30);
    options.StopTimeout = TimeSpan.FromMinutes(1);
});

// Grpc Configuration
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(o =>
{
    o.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]);
});

builder.Services.AddScoped<DiscountGrpcService>();


//General Configuration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddScoped<IBasketRepository, BasketRepository>();

//Middlewares
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket.API v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
