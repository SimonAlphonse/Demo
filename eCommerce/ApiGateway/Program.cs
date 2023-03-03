var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure http client factory

// !! Very important Note !!
// do not use localhost or ip
// use the image name without port number
// docker will take care of that for you

builder.Services.AddHttpClient("CustomerService", client =>
{
    client.BaseAddress = new Uri("http://customerservice/api/"); // !!
});

builder.Services.AddHttpClient("OrderService", client =>
{
    client.BaseAddress = new Uri("http://orderservice/api/"); // !!
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
