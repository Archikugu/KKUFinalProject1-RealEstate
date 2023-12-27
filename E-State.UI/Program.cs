using E_State.Business.Abstract;
using E_State.Business.Concrete;
using E_State.DataAccess.Abstract;
using E_State.DataAccess.Concrete;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;
using E_State.UI.Areas.Admin.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(conf => conf.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

builder.Services.AddIdentity<UserAdmin, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.SignIn.RequireConfirmedPhoneNumber = false;
    opt.SignIn.RequireConfirmedEmail = false;
    opt.SignIn.RequireConfirmedAccount = false;

    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 8;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;

    opt.User.AllowedUserNameCharacters = "abcçdefgğhıijklmnoöprsştuüvyzABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ0123456789-._";
});


builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Admin/Admin/Login/";
    opt.LogoutPath = "/Admin/Admin/LogOut";
    opt.AccessDeniedPath = "/Admin/Admin/AccessDeniedPath";
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(6);
});

builder.Services.AddSession();



builder.Services.AddScoped<IAdvertService, AdvertManager>();
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<IDistrictService, DistrictManager>();
builder.Services.AddScoped<IGeneralSettingsService, GeneralSettingsManager>();
builder.Services.AddScoped<IImagesService, ImagesManager>();
builder.Services.AddScoped<INeighbourhoodService, NeighbourhoodManager>();
builder.Services.AddScoped<ISituationService, SituationManager>();
builder.Services.AddScoped<ITypeService, TypeManager>();

builder.Services.AddScoped<IAdvertRepository, EfAdvertRepository>();
builder.Services.AddScoped<ICityRepository, EfCityRepository>();
builder.Services.AddScoped<IDistrictRepository, EfDistrictRepository>();
builder.Services.AddScoped<IGeneralSettingsRepository, EfGeneralSettingsRepository>();
builder.Services.AddScoped<IImagesRepository, EfImagesRepository>();
builder.Services.AddScoped<INeighbourhoodRepository, EfNeighbourhoodRepository>();
builder.Services.AddScoped<ISituaitonRepository, EfSituationRepository>();
builder.Services.AddScoped<ITypeRepository, EfTypeRepository>();


var app = builder.Build();

app.PrepareDatabase().GetAwaiter().GetResult();

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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
