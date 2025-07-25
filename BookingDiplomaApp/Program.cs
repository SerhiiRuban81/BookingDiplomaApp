using BookingDiplomaApp.Models.DTOs;
using BookingDiplomaApp.Profiles;
using BookingDomainClassLibrary;
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
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
