using AluguelCarros.Models;
using AluguelCarros.Repositories;
using Microsoft.EntityFrameworkCore; // Mantenha esta linha para DbContext e UseSqlite

var builder = WebApplication.CreateBuilder(args);

// --- ALTERAÇÃO AQUI ---
// Configuração do Entity Framework Core para usar SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// --- FIM DA ALTERAÇÃO ---

// Injeção de dependência do repositório
builder.Services.AddScoped<ICarroRepository, CarroRepository>();

// Adicionar suporte a Controllers e Views (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    // Em produção, usa o manipulador de erros padrão
    app.UseExceptionHandler("/Home/Error");
    // Habilitar HSTS (HTTP Strict Transport Security) em produção
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redireciona requisições HTTP para HTTPS
app.UseStaticFiles(); // Serve arquivos estáticos (CSS, JS, imagens)

app.UseRouting(); // Habilita o roteamento

app.UseAuthorization(); // Habilita a autorização (se aplicável)

// Configuração da rota padrão (controller, action, id opcional)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Carros}/{action=Index}/{id?}");

app.Run(); // Inicia a aplicação
