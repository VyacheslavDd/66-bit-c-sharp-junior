using FootballersCatalog.Infrastructure.Startups;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using FootballersCatalog.Infrastructure.Middlewares;

var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
var builder = WebApplication.CreateBuilder(args);


builder.Services.TryAddApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
	opt.IncludeXmlComments(xmlPath);
});

builder.Services.TryAddDomain(builder.Configuration);
builder.Services.TryAddServices();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
