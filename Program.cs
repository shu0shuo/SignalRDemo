using Microsoft.Extensions.DependencyInjection.Extensions;
using SignalRDemo.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR().AddJsonProtocol(options => {
	options.PayloadSerializerOptions.PropertyNamingPolicy = null;
})
	;

// cors ³]©w
string CorsPolicy = "AllowAny";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: CorsPolicy, policy =>
	{
		policy.WithOrigins("*")
		.WithHeaders("*")
		.WithMethods("*");
	});
});
//builder.Services.TryAddSingleton(typeof(CommonService)); ;
builder.Services.AddControllers();
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

app.UseCors("CorsPolicy");
app.UseRouting();
app.UseAuthorization();
//app.MapHub<MessageHub>("/offers");
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
	endpoints.MapHub<MessageHub>("/Offers/offers");
});


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
