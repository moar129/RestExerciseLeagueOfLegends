using LeagueOfLegendsLib;

var builder = WebApplication.CreateBuilder(args);

// add Cors policy to allow all origins, methods and headers
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
});
// Add services to the container.
// add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add controllers
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// add services as singleton
builder.Services.AddSingleton<ChampionsRepo>(new ChampionsRepo());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
