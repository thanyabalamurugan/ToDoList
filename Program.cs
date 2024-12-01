//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
//var app = builder.Build();
//app.UseHttpsRedirection();
//app.MapControllers();

//app.Run();
//********************************************************************************
var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
        policy.WithOrigins("http://localhost:3000") // React app's URL
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()); // Allow cookies if needed
});

// Add services
builder.Services.AddControllers();

var app = builder.Build();

// Use CORS
app.UseCors("AllowReactApp");

// Use routing and controllers
app.UseRouting();
app.MapControllers();

app.Run();



