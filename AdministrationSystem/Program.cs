using AdministrationSystem.Controllers;
using AdministrationSystem.Data;
using AdministrationSystem.Models;
using AdministrationSystem.ViewModels.UsersManagerViewModel;

var builder = WebApplication.CreateBuilder(args);

#region Services

// Controllers and Views
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<SendEmailController>();

// Models
builder.Services.AddSingleton<Users>();
builder.Services.AddSingleton<User>();
builder.Services.AddSingleton<Courses>();
builder.Services.AddSingleton<Course>();

// Data
builder.Services.AddSingleton<FirebaseConnection>();

// ViewModels
builder.Services.AddSingleton<IndexViewModel>();


#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
