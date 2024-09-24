using Microsoft.EntityFrameworkCore;
using ToDoListAplicacao.Contratos;
using ToDoListAplicacao.Implementacao;
using ToDoListPersistencia.Contexto;
using ToDoListPersistencia.Contratos;
using ToDoListPersistencia.Implementacao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITODoService, TODoService>(); 
builder.Services.AddScoped<IGeralPersistencia, GeralPersistencia>(); 
builder.Services.AddScoped<IToDoPersistencia, ToDoPersistencia>(); 


builder.Services.AddDbContext<ToDoListDBContext>(options =>
                   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));    
builder.Services.AddCors();

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseCors(x => x.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin());

 app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});
                


//.WithOpenApi();

app.Run();

