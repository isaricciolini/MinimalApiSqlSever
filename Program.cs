using Microsoft.EntityFrameworkCore;
using MinimalApiSqlSever.Context;
using MinimalApiSqlSever.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Context>
    (options => options.UseSqlServer
    ("Data Source=DESKTOP-9KVGUKN//SQLEXPRESS;Initial Catalog=ConeChinesArtesanal;Integrated Security=False;User ID=maisprati;Password=maisprati;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("CadastrarCliente", async(Cliente cliente, Context context) =>
{
    context.Cliente.Add(cliente);
    await context.SaveChangesAsync();
});

app.MapDelete("ExcluirCliente/{id}", async (int id, Context context) =>
{
    var clienteExcluir = await context.Cliente.FirstOrDefaultAsync(c => c.IdCliente == id);
    if(clienteExcluir != null)
    {
        context.Cliente.Remove(clienteExcluir);
        await context.SaveChangesAsync();
    }
    
});

app.MapGet("ConsultarClientes", async (Context context) =>
{
      return  await context.Cliente.ToListAsync();
});

app.MapGet("ConsultarCliente/{id}", async (int id, Context context) =>
{
    return await context.Cliente.FirstOrDefaultAsync(c => c.IdCliente == id);
});



app.UseSwaggerUI();

app.Run();
