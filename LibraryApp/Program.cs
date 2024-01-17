using LibraryApp.Application.Concracts.Persistance;
using LibraryApp.Infrastructure.Persistance;
using LibraryApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Aþaðýdaki kýsým migration için eklenir.
builder.Services.AddDbContext<LibraryAppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));
//Aþaðýdaki kýsým neden yapýldý, nasýl yapýldý? 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
