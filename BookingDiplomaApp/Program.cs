using BookingDiplomaApp.Models.DTOs;
using BookingDiplomaApp.Profiles;
using BookingDomainClassLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
string connStr = builder.Configuration.GetConnectionString("LocalMSSQLDb") ??
    throw new InvalidOperationException("You should provide Db connection string!");
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseSqlServer(connStr));
//builder.Services.AddAutoMapper(config => {
//    config.CreateMap<ApartmentDTO, Apartment>()
//    .ReverseMap();
//});
builder.Services.AddAutoMapper(configAction: config => { },
    typeof(ApartmentProfile),
    typeof(FacilityProfile),
    typeof(PhotoProfile)
    );
builder.Services.AddIdentity<ShopUser, IdentityRole>(
    options => {
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
