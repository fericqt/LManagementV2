using LManagement.Data.DBContext;
using LManagement.Data.DBInitializer;
using LManagement.Data.Repository;
using LManagement.Data.Repository.IRepository;
using LManagement.Utility;
using LManagement.Utility.IUtilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LManagementDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => {
    opt.LoginPath = "/UserAccount/Login";
});
builder.Services.AddTransient<IGuid, GuidImplementation>();


builder.Services.AddAuthorization(opt => {
    opt.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
SeedDatabase();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserAccount}/{action=Login}/{id?}"
    
 );



app.Run();
void SeedDatabase() {
    using (var scope = app.Services.CreateScope()) {

        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();

    }
}
