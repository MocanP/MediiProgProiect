using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediiProgProiect.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/MasiniC");
    options.Conventions.AllowAnonymousToPage("/MasiniC/Index");
    options.Conventions.AllowAnonymousToPage("/MasiniC/Details");
    options.Conventions.AuthorizeFolder("/Membri", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Vanzatori");
    options.Conventions.AllowAnonymousToPage("/MasiniC/Index");
    options.Conventions.AllowAnonymousToPage("/MasiniC/Details");

});


builder.Services.AddDbContext<MediiProgProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediiProgProiectContext") ?? throw new InvalidOperationException("Connection string 'MediiProgProiectContext' not found.")));

builder.Services.AddDbContext<AuthContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("MediiProgProiectContext") ?? throw new InvalidOperationException("Connection string 'MediiProgProiectContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<AuthContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
